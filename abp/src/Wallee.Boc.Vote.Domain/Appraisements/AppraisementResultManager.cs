using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;
using Wallee.Boc.Vote.AppraisementResults;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementResultManager : DomainService
    {
        public AppraisementResultManager(
            IAppraisementResultRepository appraisementResultRepository)
        {
            AppraisementResultRepository = appraisementResultRepository;
        }
        public IAppraisementResultRepository AppraisementResultRepository { get; }

        public AppraisementResult SetDetails(AppraisementResult result, IEnumerable<AppraisementResultScoreDetail> details)
        {
            result.SetDetails(details);

            if (result.Category == EvaluationCategory.部门评价)
            {
                foreach (var item in result.Details)
                {
                    string contentScore = Regex.Replace(item.Content, @"[^0-9]+", "");
                    if (item.Score > decimal.Parse(contentScore))
                    {
                        throw new UserFriendlyException($"{item.Content}的分值超出了限定");
                    }
                }
            }

            if (result.Category == EvaluationCategory.满意度调查 || result.Category == EvaluationCategory.部门评价)
            {
                if (result.Score < 60 || result.Score > 99)
                {
                    throw new UserFriendlyException("评测得分的范围应为[60,99]");
                }
            }

            return result;
        }
    }
}
