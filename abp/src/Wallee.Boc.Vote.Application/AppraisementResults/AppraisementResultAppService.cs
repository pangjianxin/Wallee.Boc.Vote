using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
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
            if (await AppraisementResultRepository.AnyAsync(it =>
                it.AppraisementId == input.AppraisementId && it.ClientIp == input.ClientIp))
            {
                throw new UserFriendlyException("你已评价过该主体");
            }

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

                result.SetDetails(detail.ScoreDetails.Select(it => new AppraisementResultDetail(result.Id, it.EvaluationContentId, it.Content, it.Score, it.Comment)));

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
