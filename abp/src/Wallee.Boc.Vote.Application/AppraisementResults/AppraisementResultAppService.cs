using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultAppService :
        CrudAppService<AppraisementResult, AppraisementResultDto, Guid, GetAppraisementResultsInputDto, AppraisementResultCreateDto, AppraisementResultUpdateDto>,
        IAppraisementResultAppService, ITransientDependency
    {
        public AppraisementResultAppService(
            IAppraisementResultRepository appraisementResultRepository,
            AppraisementResultManager appraisementResultManager) : base(appraisementResultRepository)
        {
            AppraisementResultRepository = appraisementResultRepository;
            AppraisementResultManager = appraisementResultManager;
        }

        public IAppraisementResultRepository AppraisementResultRepository { get; }
        public AppraisementResultManager AppraisementResultManager { get; }

        public async override Task<AppraisementResultDto> CreateAsync(AppraisementResultCreateDto input)
        {
            var result = new AppraisementResult(
                GuidGenerator.Create(),
                input.AppraisementId,
                input.Evaluator,
                input.CandidateId,
                input.ClientIpAddress,
                input.Category);

            var scoreLst = new List<AppraisementResultScoreDetail>();

            foreach (var item in input.ContentScores)
            {
                scoreLst.Add(new AppraisementResultScoreDetail(result.Id, item.EvaluationContentId, item.Content, item.Score));
            }

            result = AppraisementResultManager.SetDetails(result, scoreLst);

            await AppraisementResultManager.CheckAsync(result);

            await AppraisementResultRepository.InsertAsync(result);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<AppraisementResult, AppraisementResultDto>(result);
        }
        protected override async Task<IQueryable<AppraisementResult>> CreateFilteredQueryAsync(GetAppraisementResultsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
