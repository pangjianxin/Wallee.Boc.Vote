using System;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitCreateDto
    {
        /// <summary>
        /// 组织机构号
        /// </summary>
        public Guid OrganizationUnitId { get; set; }
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; set; }

        public Guid SuperiorId { get; set; }
        public string Description { get; set; } = default!;
    }
}
