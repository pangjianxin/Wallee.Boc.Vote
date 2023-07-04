using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
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
            if (await AppraisementResultRepository.AnyAsync(
                it => it.CreatorId == CurrentUser.Id &&
                it.AppraisementId == input.AppraisementId &&
                it.CandidateId == input.CandidateId))
            {
                throw new UserFriendlyException("你已评价过该主体");

            }

            var result = new AppraisementResult(
                GuidGenerator.Create(),
                input.AppraisementId,
                input.CandidateId,
                input.Category);

            var scoreLst = new List<AppraisementResultScoreDetail>();

            foreach (var item in input.ContentScores)
            {
                scoreLst.Add(new AppraisementResultScoreDetail(result.Id, item.EvaluationContentId, item.Content, item.Score, item.Comment));
            }

            result = AppraisementResultManager.SetDetails(result, scoreLst);

            await AppraisementResultRepository.InsertAsync(result);

            return ObjectMapper.Map<AppraisementResult, AppraisementResultDto>(result);
        }
        protected override async Task<IQueryable<AppraisementResult>> CreateFilteredQueryAsync(GetAppraisementResultsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
