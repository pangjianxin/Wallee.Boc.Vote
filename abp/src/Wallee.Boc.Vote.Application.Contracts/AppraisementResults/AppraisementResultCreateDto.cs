using System;
using System.Collections.Generic;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultCreateDto
    {
        public Guid AppraisementId { get; set; }
        /// <summary>
        /// 评测人
        /// </summary>
        public Guid Evaluator { get; set; }
        /// <summary>
        /// 被评测对象
        /// </summary>
        public Guid CandidateId { get; set; }
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string ClientIpAddress { get; set; } = null!;
        /// <summary>
        /// 分项评分结果
        /// </summary>
        public List<AppraisementResultScoreDetailDto> ContentScores { get; set; } = null!;
        /// <summary>
        /// 评测分类
        /// </summary>
        public EvaluationCategory Category { get; set; }
    }
}
