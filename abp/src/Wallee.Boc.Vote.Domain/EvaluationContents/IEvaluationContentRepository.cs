using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public interface IEvaluationContentRepository : IRepository<EvaluationContent, Guid>
    {
    }
}
