using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultCreateDto : IValidatableObject
    {
        public Guid AppraisementId { get; set; }
        /// <summary>
        /// 被评测对象
        /// </summary>
        public Guid CandidateId { get; set; }
        /// <summary>
        /// 分项评分结果
        /// </summary>
        public List<AppraisementResultScoreDetailDto> ContentScores { get; set; } = null!;
        /// <summary>
        /// 评测分类
        /// </summary>
        public EvaluationCategory Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var item in ContentScores)
            {
                if (item.Score < 60 || item.Score > 99)
                {
                    yield return new ValidationResult($"{item.Content}该项打分不合规,区间为(60,99)");
                }
            }
        }
    }
}
