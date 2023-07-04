﻿using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResult : AuditedAggregateRoot<Guid>
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected AppraisementResult() { }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public AppraisementResult(
            Guid id,
            Guid appraisementId,
            Guid candidateId,
            EvaluationCategory category) : base(id)
        {
            AppraisementId = appraisementId;
            CandidateId = candidateId;
            Category = category;
            Details = new List<AppraisementResultScoreDetail>();
        }
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
        public ICollection<AppraisementResultScoreDetail> Details { get; private set; }
        /// <summary>
        /// 相关得分
        /// </summary>
        public decimal Score { get; private set; }
        /// <summary>
        /// 评测分类
        /// </summary>
        public EvaluationCategory Category { get; private set; }

        public void SetDetails(IEnumerable<AppraisementResultScoreDetail> details)
        {
            if (Details.Count > 0)
            {
                Details.Clear();
            }

            foreach (var item in details)
            {
                Details.Add(item);
            }

            var score = details.Sum(it => it.Score);

            Score = score;
        }
    }
}
