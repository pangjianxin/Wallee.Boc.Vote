using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.Vote.EntityFrameworkCore;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public class AppraisementResultRepository : EfCoreRepository<VoteDbContext, AppraisementResult, Guid>, IAppraisementResultRepository, ITransientDependency
    {
        public AppraisementResultRepository(IDbContextProvider<VoteDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
