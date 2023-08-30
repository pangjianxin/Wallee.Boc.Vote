using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultDetailDto : EntityDto
    {
        public Guid AppraisementResultId { get; set; }
        public Guid EvaluationContentId { get; set; }
        public string Content { get; set; } = default!;
        public decimal Score { get; set; }
        public decimal Weight { get; set; }
        public string? Comment { get; set; }
        public decimal FinalScore { get; set; }
    }
}
