using System;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 被评测对象
        /// </summary>
        public Guid CandidateId { get; set; }
        /// <summary>
        /// 评测内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 相关得分
        /// </summary>
        public decimal Score { get; set; }
        /// <summary>
        /// 评测分类
        /// </summary>
        public EvaluationCategory Category { get; set; }
    }
}
