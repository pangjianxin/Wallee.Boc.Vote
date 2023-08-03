using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultDetailDto : EntityDto
    {
        public Guid AppraisementResultId { get; private set; }
        public Guid EvaluationContentId { get; private set; }
        public string Content { get; private set; } = default!;
        public decimal Score { get; private set; }
        /// <summary>
        /// 备注/建议等
        /// </summary>
        public string? Comment { get; private set; }
    }
}
