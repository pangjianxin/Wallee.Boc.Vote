using System;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultScoreDetailDto
    {
        public Guid EvaluationContentId { get; set; }
        public string Content { get; set; } = null!;
        public decimal Score { get; set; }
        /// <summary>
        /// 备注/建议等
        /// </summary>
        public string? Comment { get; set; }
    }
}
