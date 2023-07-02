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
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Json;
using Wallee.Boc.Vote.Blobs;
using Wallee.Boc.Vote.Identity;
using Wallee.Boc.Vote.RulesEngines;
using Wallee.Boc.Vote.StringExtensions;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitAppService :
        CrudAppService<CandidateOrgUnit, CandidateOrgUnitDto, Guid, GetCandidateOrgUnitsInputDto, CandidateOrgUnitCreateDto, CandidateOrgUnitUpdateDto>,
        ICandidateOrgUnitAppService
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        public readonly ICandidateOrgUnitRepository _candidateOrgUnitRepository;
        public IIdentityUserAppService _userAppService;
        public IBlobContainer<CandidateOrgUnitEvaContainer> _candidateOrgUnitEvaContainer;

        public CandidateOrgUnitAppService(ICandidateOrgUnitRepository candidateOrgUnitRepository,
            IIdentityUserAppService userAppService,
            IBlobContainer<CandidateOrgUnitEvaContainer> candidateOrgUnitEvaContainer,
            IJsonSerializer jsonSerializer,
            IOrganizationUnitRepository organizationUnitRepository) : base(candidateOrgUnitRepository)
        {
            _candidateOrgUnitRepository = candidateOrgUnitRepository;
            _userAppService = userAppService;
            _candidateOrgUnitEvaContainer = candidateOrgUnitEvaContainer;
            _jsonSerializer = jsonSerializer;
            _organizationUnitRepository = organizationUnitRepository;
        }




        public async override Task<CandidateOrgUnitDto> CreateAsync(CandidateOrgUnitCreateDto input)
        {
            var superior = await _userAppService.GetAsync(input.SuperiorId) ?? throw new UserFriendlyException("未找到相关用户，请核对");

            if (await _candidateOrgUnitRepository.AnyAsync(it => it.OrganizationUnitId == input.OrganizationUnitId))
            {
                throw new UserFriendlyException("已存在该机构,不能重复添加");
            }

            var orgUnit = await _organizationUnitRepository.GetAsync(input.OrganizationUnitId) ?? throw new UserFriendlyException("未找到相关机构信息,请核对");

            var candidateOrgUnit = new CandidateOrgUnit(GuidGenerator.Create(), orgUnit.Id, orgUnit.Code, orgUnit.DisplayName, superior.Id, superior.Name, input.Category);

            await _candidateOrgUnitRepository.InsertAsync(candidateOrgUnit);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(candidateOrgUnit);
        }

        public async override Task<CandidateOrgUnitDto> UpdateAsync(Guid id, CandidateOrgUnitUpdateDto input)
        {
            CandidateOrgUnit candidateOrgUnit = await _candidateOrgUnitRepository.GetAsync(id);
            candidateOrgUnit.ConcurrencyStamp = input.ConcurrencyStamp;

            if (candidateOrgUnit.OrganizationUnitId != input.OrganizationUnitId)
            {
                if (await _candidateOrgUnitRepository.AnyAsync(it => it.OrganizationUnitId == input.OrganizationUnitId))
                {
                    throw new UserFriendlyException($"组织机构已存在");
                }
            }
            var organizationUnit = await _organizationUnitRepository.GetAsync(input.OrganizationUnitId);
            candidateOrgUnit.SetOrgUnitInfo(organizationUnit.Id, organizationUnit.Code, organizationUnit.DisplayName);

            var user = await _userAppService.GetAsync(input.SuperiorId);
            candidateOrgUnit.SetSuperior(user.Id, user.Name);

            candidateOrgUnit.SetCategory(input.Category);

            candidateOrgUnit.SetActive(input.IsActive);

            await _candidateOrgUnitRepository.UpdateAsync(candidateOrgUnit);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(candidateOrgUnit);
        }

        public async Task<CandidateOrgUnitDto> UpdateSuperiorAsync(Guid id, CandidateOrgUnitUpdateSuperiorDto input)
        {
            var department = await _candidateOrgUnitRepository.GetAsync(id);

            department.ConcurrencyStamp = input.ConcurrencyStamp;

            var superior = await _userAppService.GetAsync(input.SuperiorId) ?? throw new UserFriendlyException("未找到相关用户，请查证");

            department.SetSuperior(superior.Id, superior.Name);

            await _candidateOrgUnitRepository.UpdateAsync(department);

            return ObjectMapper.Map<CandidateOrgUnit, CandidateOrgUnitDto>(department);
        }

        public async Task UpdateRulesEngine(string workflowDef)
        {
            if (!workflowDef.IsWorkflowValid(_jsonSerializer))
            {
                throw new UserFriendlyException("json格式不正确，请重新输入");
            }
            var bytes = workflowDef.GetBytes();

            await _candidateOrgUnitEvaContainer.SaveAsync(BlobFileConsts.CandidateOrgUnitEvaFile, bytes, true);
        }

        public async Task<string> GetRulesEngine()
        {
            if (await _candidateOrgUnitEvaContainer.ExistsAsync(BlobFileConsts.CandidateOrgUnitEvaFile))
            {
                var stream = await _candidateOrgUnitEvaContainer.GetOrNullAsync(BlobFileConsts.CandidateOrgUnitEvaFile);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            return string.Empty;
        }

        public async Task<List<CandidateOrgUnitDto>> GetCandidateOrgUnitEvaList()
        {
            PredicateResult? predicateResult = null;

            var stream = await _candidateOrgUnitEvaContainer.GetAsync(BlobFileConsts.CandidateOrgUnitEvaFile);

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
                var list = await _candidateOrgUnitRepository.GetListDynamicallyAsync(predicateResult.Predicate, predicateResult.Parameters);
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
