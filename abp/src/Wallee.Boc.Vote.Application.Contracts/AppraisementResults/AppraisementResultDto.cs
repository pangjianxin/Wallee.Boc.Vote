using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultDto : AuditedEntityDto<Guid>
    {
        public string ClientIp { get; private set; } = default!;
        public string RuleName { get; private set; } = default!;
        /// <summary>
        /// 评测活动Id
        /// </summary>
        public Guid AppraisementId { get; private set; }
        /// <summary>
        /// 被评测对象
        /// </summary>
        public Guid CandidateId { get; private set; }
        /// <summary>
        /// 明细
        /// </summary>
        public ICollection<AppraisementResultDetailDto> Details { get; private set; } = default!;
        /// <summary>
        /// 相关得分
        /// </summary>
        public decimal Score { get; private set; }
        /// <summary>
        /// 评测分类
        /// </summary>
        public EvaluationCategory Category { get; private set; }
    }
}
