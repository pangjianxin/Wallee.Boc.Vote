using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.Vote.Appraisements
{
    /// <summary>
    /// 评价内容
    /// </summary>
    public class EvaluationContent : AuditedAggregateRoot<Guid>
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected EvaluationContent() { }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

        public EvaluationContent(
            Guid id,
            string name,
            string description,
            EvaluationCategory category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }
        /// <summary>
        /// 履职评价名称(项目)
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 履职评价描述(评价标准)
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 评价内容分类
        /// </summary>
        public EvaluationCategory Category { get; private set; }
        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            Name = name;
        }
        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description)
        {
            Description = description;
        }
        /// <summary>
        /// 设置分类
        /// </summary>
        /// <param name="category"></param>
        public void SetCategory(EvaluationCategory category)
        {
            Category = category;
        }
    }
}
