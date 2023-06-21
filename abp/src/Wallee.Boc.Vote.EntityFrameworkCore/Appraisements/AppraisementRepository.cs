using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.Vote.EntityFrameworkCore;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementRepository : EfCoreRepository<VoteDbContext, Appraisement, Guid>, IAppraisementRepository, ITransientDependency
    {
        public AppraisementRepository(IDbContextProvider<VoteDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
