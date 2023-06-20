using Boc.Vote.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementResultManager : DomainService
    {
        public AppraisementResultManager(
            IAppraisementResultRepository appraisementResultRepository,
            ICurrentUser currentUser)
        {
            AppraisementResultRepository = appraisementResultRepository;
            CurrentUser = currentUser;
        }
        public IAppraisementResultRepository AppraisementResultRepository { get; }
        public ICurrentUser CurrentUser { get; }

        public async Task CheckAsync(AppraisementResult result)
        {
            var recoredExisted = await AsyncExecuter.AnyAsync(
                               (await AppraisementResultRepository.GetQueryableAsync())
                                   .Where(it => it.AppraisementId == result.AppraisementId
                                   && it.CandidateId == result.CandidateId
                                   && it.Evaluator == result.Evaluator));

            //履职评价下评价人均为实名，所以能够限制同一个评价人对同一个被评价人评价次数
            //目前部门评价下评价人也都是实名，所以和履职评价一样
            if (result.Category == EvaluationCategory.履职评价
                || result.Category == EvaluationCategory.部门评价)
            {
                if (recoredExisted)
                {
                    throw new UserFriendlyException($"针对同一个人评价记录已存在，不能重复提交");
                }
            }
            //满意度评价下某些评价人不是实名，很多人在用同一个账号，所以要限制针对同一个账号对同一个候选人/机构在同一台电脑的评价次数
            if (result.Category == EvaluationCategory.满意度调查)
            {
                if (CurrentUser.Roles.First() == "员工代表")
                {
                    var recordCount = await AsyncExecuter.CountAsync((await AppraisementResultRepository.GetQueryableAsync())
                                       .Where(it =>
                                       it.Evaluator == result.Evaluator
                                       && it.CandidateId == result.CandidateId
                                       && it.AppraisementId == result.AppraisementId
                                       && it.ClientIpAddress == result.ClientIpAddress));
                    if (recordCount >= 4)
                    {
                        throw new UserFriendlyException("您不能在同一台电脑对同一个被评价主体评价超过4次");
                    }
                }
                else
                {
                    if (recoredExisted)
                    {
                        throw new UserFriendlyException($"针对同一个人评价记录已存在，不能重复提交");
                    }
                }
            }
        }


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
