using System;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public interface IAppraisementResultAppService : ICrudAppService<AppraisementResultDto, Guid, GetAppraisementResultsInputDto, AppraisementResultCreateDto, AppraisementResultUpdateDto>, ITransientDependency
    {
    }
}
