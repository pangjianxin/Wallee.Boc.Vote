using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.Vote.Appraisements
{
    /// <summary>
    /// 评测结果明细数据
    /// </summary>
    public class AppraisementResultScoreDetail : Entity
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected AppraisementResultScoreDetail() { }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

        public AppraisementResultScoreDetail(
            Guid appraisementReusltId,
            Guid evaluationContentId,
            string content,
            decimal score)
        {
            AppraisementResultId = appraisementReusltId;
            EvaluationContentId = evaluationContentId;
            Content = content;
            Score = score;
        }
        public Guid AppraisementResultId { get; private set; }
        public Guid EvaluationContentId { get; private set; }
        public string Content { get; private set; }
        public decimal Score { get; private set; }

        public override object[] GetKeys()
        {
            return new object[] { AppraisementResultId, EvaluationContentId };
        }
    }
}
