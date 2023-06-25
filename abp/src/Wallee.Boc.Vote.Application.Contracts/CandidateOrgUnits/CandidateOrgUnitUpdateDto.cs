using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitUpdateDto : IHasConcurrencyStamp
    {
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; set; }
        public Guid SuperiorId { get; set; }
        public Guid OrganizationUnitId { get; set; }
        public string ConcurrencyStamp { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
