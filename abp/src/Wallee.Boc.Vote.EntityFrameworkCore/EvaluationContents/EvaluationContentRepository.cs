using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.Vote.EntityFrameworkCore;

namespace Wallee.Boc.Vote.EvaluationContents
{
    public class EvaluationContentRepository : EfCoreRepository<VoteDbContext, EvaluationContent, Guid>, IEvaluationContentRepository, ITransientDependency
    {
        public EvaluationContentRepository(IDbContextProvider<VoteDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
