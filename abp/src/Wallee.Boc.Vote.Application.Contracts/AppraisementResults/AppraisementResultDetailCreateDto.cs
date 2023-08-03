using System;
using System.Collections.Generic;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultDetailCreateDto
    {
        public Guid CandidateId { get; set; }
        public List<AppraisementResultDetailScoreDto> ScoreDetails { get; set; } = default!;
    }

    public class AppraisementResultDetailScoreDto
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
