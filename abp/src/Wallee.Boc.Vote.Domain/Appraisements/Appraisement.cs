using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.Vote.Appraisements
{
    /// <summary>
    /// 测评活动
    /// </summary>
    public class Appraisement : AuditedAggregateRoot<Guid>
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected Appraisement() { }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public Appraisement(
            Guid id,
            string name,
            string description,
            AppraisementCategory category,
            DateTime start,
            DateTime end) : base(id)
        {

            Name = name;
            Category = category;
            Description = description;
            Start = start;
            End = end;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AppraisementCategory Category { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public void SetName(string name)
        {
            Name = Check.NotNullOrEmpty(name, nameof(name));
        }

        public void SetDescription(string description)
        {
            Description = Check.NotNullOrEmpty(description, nameof(description));
        }

        public void SetStart(DateTime start)
        {
            Start = start;
        }

        public void SetEnd(DateTime end)
        {
            End = end;
        }

        public void SetCategory(AppraisementCategory category)
        {
            Category = category;
        }
    }
}
