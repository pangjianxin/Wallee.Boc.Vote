using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public class EvaluationContentManager : DomainService
    {
        private readonly IEvaluationContentRepository _evaluationContentRepository;

        public EvaluationContentManager(IEvaluationContentRepository evaluationContentRepository)
        {
            _evaluationContentRepository = evaluationContentRepository;
        }

        public async Task<EvaluationContent> CreateAsync(string name, string description, EvaluationCategory evaluationCategory)
        {
            if (await _evaluationContentRepository.AnyAsync(it => it.Name == name))
            {
                throw new UserFriendlyException($"已存在名称为{name}的评估指标名称");
            }
            return new EvaluationContent(GuidGenerator.Create(), name, description, evaluationCategory);
        }
    }
}
