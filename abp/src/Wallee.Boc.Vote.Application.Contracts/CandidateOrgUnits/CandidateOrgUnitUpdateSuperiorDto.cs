using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitUpdateSuperiorDto : IHasConcurrencyStamp
    {
        public Guid SuperiorId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}
