using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultCreateDto : IValidatableObject
    {
        public Guid AppraisementId { get; set; }
        public string? ClientIp { get; set; }
        public string RoleName { get; set; } = default!;
        /// <summary>
        /// 分项评分结果
        /// </summary>
        public List<AppraisementResultDetailCreateDto> Details { get; set; } = null!;
        /// <summary>
        /// 评测分类
        /// </summary>
        public EvaluationCategory Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var detail in Details)
            {
                foreach (var scoreDetail in detail.ScoreDetails)
                {
                    if (scoreDetail.Score < 60 || scoreDetail.Score > 99)
                    {
                        yield return new ValidationResult($"{scoreDetail.Content}该项打分不合规,区间为(60,99)");
                    }
                }
            }
        }
    }
}
