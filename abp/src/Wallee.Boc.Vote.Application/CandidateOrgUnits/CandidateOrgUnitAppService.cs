using AutoFilterer.Extensions;
using RulesEngine.Extensions;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Json;
using Wallee.Boc.Vote.Blobs;
using Wallee.Boc.Vote.Identity;
using Wallee.Boc.Vote.RulesEngines;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitAppService :
        CrudAppService<CandidateOrgUnit, CandidateOrgUnitDto, Guid, GetCandidateOrgUnitsInputDto, CandidateOrgUnitCreateDto, CandidateOrgUnitUpdateDto>,
        ICandidateOrgUnitAppService, ITransientDependency
    {
        private readonly IJsonSerializer _jsonSerializer;

        public CandidateOrgUnitAppService(ICandidateOrgUnitRepository candidateOrgUnitRepository,
            IIdentityUserAppService userAppService,
            IBlobContainer<DepEvaAnalysisContainer> depEvaAnalysisContainer,
            IJsonSerializer jsonSerializer) : base(candidateOrgUnitRepository)
        {
            CandidateOrgUnitRepository = candidateOrgUnitRepository;
            UserAppService = userAppService;
            DepEvaAnalysisContainer = depEvaAnalysisContainer;
            _jsonSerializer = jsonSerializer;
        }

        public ICandidateOrgUnitRepository CandidateOrgUnitRepository { get; }
        public IIdentityUserAppService UserAppService { get; }
        public IBlobContainer<DepEvaAnalysisContainer> DepEvaAnalysisContainer { get; }

        public async override Task<CandidateOrgUnitDto> CreateAsync(CandidateOrgUnitCreateDto input)
        {
            var superior = await UserAppService.GetAsync(input.SuperiorId) ?? throw new UserFriendlyException("未找到相关用户，请核对");

            var candidateOrgUnit = new CandidateOrgUnit(GuidGenerator.Create(), input.OrganizationUnitId, input.OrganCode, input.OrganName, superior.Id, superior.Name, input.Category);

            await CandidateOrgUnitRepository.InsertAsync(candidateOrgUnit);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(candidateOrgUnit);
        }

        public async override Task<CandidateOrgUnitDto> UpdateAsync(Guid id, CandidateOrgUnitUpdateDto input)
        {
            CandidateOrgUnit candidateOrgUnit = await CandidateOrgUnitRepository.GetAsync(id);

            candidateOrgUnit.ConcurrencyStamp = input.ConcurrencyStamp;

            candidateOrgUnit.SetOrgUnitInfo(input.OrganCode, input.OrganName);

            candidateOrgUnit.SetCategory(input.Category);

            await CandidateOrgUnitRepository.UpdateAsync(candidateOrgUnit);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(candidateOrgUnit);
        }

        public async Task<CandidateOrgUnitDto> UpdateSuperiorAsync(Guid id, CandidateOrgUnitUpdateSuperiorDto input)
        {
            var department = await CandidateOrgUnitRepository.GetAsync(id);

            department.ConcurrencyStamp = input.ConcurrencyStamp;

            var superior = await UserAppService.GetAsync(input.SuperiorId) ?? throw new UserFriendlyException("未找到相关用户，请查证");

            department.SetSuperior(superior.Id, superior.Name);

            await CandidateOrgUnitRepository.UpdateAsync(department);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(department);
        }

        public async Task<List<CandidateOrgUnitDto>> GetCandidateOrgUnitEvaList()
        {
            PredicateResult? predicateResult = null;

            var stream = await DepEvaAnalysisContainer.GetAsync(BlobFileConsts.DepartmentEvaAnalysisFile);

            stream.Position = 0;

            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();

                var workflows = _jsonSerializer.Deserialize<List<Workflow>>(content);

                //resettings 用户将system命名空间以外的类型带入规则引擎
                var rulesEngineResetting = new ReSettings()
                {
                    CustomTypes = new Type[]
                    {
                      typeof(PredicateResult)
                    }
                };

                var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray(), rulesEngineResetting);

                //rule parameter用于规则引擎计算时传入的参数，还有另外一种local params，在规则引擎中进行定义
                var ruleParameter = new RuleParameter("user", new
                {
                    role = CurrentUser.Roles.FirstOrDefault(),
                    ehr = CurrentUser.SurName,
                    brNo = CurrentUser.FindOrganizationUnits().First()
                });

                var results = await rulesEngine.ExecuteAllRulesAsync("DepartmentEvaAnalysis", ruleParameter);

                results.OnSuccess(successEvent =>
                {
                    predicateResult = results.First(it => it.Rule.SuccessEvent == successEvent).ActionResult.Output as PredicateResult;
                });

            }
            if (predicateResult != null)
            {
                var list = await CandidateOrgUnitRepository.GetListDynamicallyAsync(predicateResult.Predicate, predicateResult.Parameters);
                return ObjectMapper.Map<List<CandidateOrgUnit>, List<CandidateOrgUnitDto>>(list);
            }
            else
            {
                return new List<CandidateOrgUnitDto>();
            }
        }

        protected override async Task<IQueryable<CandidateOrgUnit>> CreateFilteredQueryAsync(GetCandidateOrgUnitsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
