using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.Vote.EntityFrameworkCore;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitRepository : EfCoreRepository<VoteDbContext, CandidateOrgUnit, Guid>, ICandidateOrgUnitRepository
    {
        public CandidateOrgUnitRepository(IDbContextProvider<VoteDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<CandidateOrgUnit>> GetListDynamicallyAsync(string predicate, params object[] parameters)
        {
            return await (await GetDbSetAsync()).Where(predicate, parameters).ToListAsync();
        }
    }
}
