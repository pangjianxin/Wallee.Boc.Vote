using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.Vote.Appraisements
{
    public interface IAppraisementRepository : IRepository<Appraisement, Guid>
    {
    }
}
