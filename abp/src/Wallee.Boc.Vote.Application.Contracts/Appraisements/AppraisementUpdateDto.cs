using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementUpdateDto : IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public AppraisementCategory Category { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ConcurrencyStamp { get; set; } = null!;
    }
}
