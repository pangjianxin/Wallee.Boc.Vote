using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.Vote.AppraisementResults
{
    /// <summary>
    /// 评测结果明细数据
    /// </summary>
    public class AppraisementResultScoreDetail : AuditedEntity
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected AppraisementResultScoreDetail() { }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

        public AppraisementResultScoreDetail(
            Guid appraisementReusltId,
            Guid evaluationContentId,
            string content,
            decimal score,
            string? comment)
        {
            AppraisementResultId = appraisementReusltId;
            EvaluationContentId = evaluationContentId;
            Content = content;
            Score = score;
            Comment = comment;
        }
        public Guid AppraisementResultId { get; private set; }
        public Guid EvaluationContentId { get; private set; }
        public string Content { get; private set; }
        public decimal Score { get; private set; }
        /// <summary>
        /// 备注/建议等
        /// </summary>
        public string? Comment { get; private set; }

        public override object[] GetKeys()
        {
            return new object[] { AppraisementResultId, EvaluationContentId };
        }
    }
}
