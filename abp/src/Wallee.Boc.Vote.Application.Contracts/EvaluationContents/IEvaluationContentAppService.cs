using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public interface IEvaluationContentAppService :
        ICrudAppService<EvaluationContentDto, Guid, GetEvaluationContentInputDto, EvaluationContentCreateDto, EvaluationContentUpdateDto>,
        ITransientDependency
    {
        Task<List<EvaluationContentDto>> GetListByCategory(EvaluationCategory category);
    }
}
