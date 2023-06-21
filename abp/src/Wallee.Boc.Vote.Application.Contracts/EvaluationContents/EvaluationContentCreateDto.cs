using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public class EvaluationContentCreateDto
    {
        /// <summary>
        /// 履职评价名称(项目)
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 履职评价描述(评价标准)
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 评价内容分类
        /// </summary>
        public EvaluationCategory Category { get; set; }
    }
}
