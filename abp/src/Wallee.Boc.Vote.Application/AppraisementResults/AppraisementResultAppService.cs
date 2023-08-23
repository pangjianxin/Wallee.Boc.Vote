using AutoFilterer.Extensions;
using RulesEngine.Extensions;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;
using Wallee.Boc.Vote.Appraisements;
using Wallee.Boc.Vote.Blobs;
using Wallee.Boc.Vote.RulesEngines;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultAppService :
        CrudAppService<AppraisementResult, AppraisementResultDto, Guid, GetAppraisementResultsInputDto, AppraisementResultCreateDto, AppraisementResultUpdateDto>,
        IAppraisementResultAppService, ITransientDependency
    {
        private readonly IRulesEngineProvider _rulesEngineProvider;
        private readonly IJsonSerializer _jsonSerializer;

        public AppraisementResultAppService(
            IAppraisementResultRepository appraisementResultRepository,
            AppraisementResultManager appraisementResultManager,
            IRulesEngineProvider rulesEngineProvider,
            IJsonSerializer jsonSerializer) : base(appraisementResultRepository)
        {
            AppraisementResultRepository = appraisementResultRepository;
            AppraisementResultManager = appraisementResultManager;
            _rulesEngineProvider = rulesEngineProvider;
            _jsonSerializer = jsonSerializer;
        }

        public IAppraisementResultRepository AppraisementResultRepository { get; }
        public AppraisementResultManager AppraisementResultManager { get; }

        public async override Task<AppraisementResultDto> CreateAsync(AppraisementResultCreateDto input)
        {
            if (await AppraisementResultRepository.AnyAsync(it => it.AppraisementId == input.AppraisementId && it.ClientIp == input.ClientIp))
            {
                throw new UserFriendlyException("你已评价过该主体");
            }

            var workflow = await _rulesEngineProvider.GetWorkflow(BlobConsts.AppraisementResultRuleWeight);

            var workflows = _jsonSerializer.Deserialize<List<Workflow>>(workflow);

            var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray());

            var ruleParameters = new RuleParameter("roleName", input.RuleName);

            var results = await rulesEngine.ExecuteAllRulesAsync(BlobConsts.AppraisementResultRuleWeight, ruleParameters);

            var weight = default(decimal);

            results.OnSuccess(successEvent =>
            {
                var successResult = results.First(it => it.Rule.SuccessEvent == successEvent).ActionResult.Output;
                weight = Convert.ToDecimal(successResult);
            });

            var resultList = new List<AppraisementResult>();

            foreach (var detail in input.Details)
            {
                var result = new AppraisementResult(
                    GuidGenerator.Create(),
                    input.AppraisementId,
                    detail.CandidateId,
                    input.ClientIp!,
                    input.RuleName,
                    input.Category);

                result.SetDetails(detail.ScoreDetails.Select(it => new AppraisementResultDetail(result.Id, it.EvaluationContentId, it.Content, it.Score * weight, it.Comment)));

                resultList.Add(result);
            }


            await AppraisementResultRepository.InsertManyAsync(resultList);

            return ObjectMapper.Map<AppraisementResult, AppraisementResultDto>(resultList.First());
        }
        protected override async Task<IQueryable<AppraisementResult>> CreateFilteredQueryAsync(GetAppraisementResultsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
