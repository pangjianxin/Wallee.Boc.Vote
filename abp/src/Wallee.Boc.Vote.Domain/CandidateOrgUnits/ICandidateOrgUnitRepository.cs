using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public interface ICandidateOrgUnitRepository : IRepository<CandidateOrgUnit, Guid>
    {
        Task<List<CandidateOrgUnit>> GetListDynamicallyAsync(string predicate, params object[] parameters);
    }
}
