using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.Vote.AppraisementResults
{
    public interface IAppraisementResultRepository : IRepository<AppraisementResult, Guid>
    {

    }
}
