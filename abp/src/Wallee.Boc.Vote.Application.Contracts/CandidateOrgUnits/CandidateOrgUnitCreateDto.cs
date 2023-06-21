using System;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitCreateDto
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OrganName { get; set; } = null!;
        /// <summary>
        /// 部门号
        /// </summary>
        public string OrganCode { get; set; } = null!;
        /// <summary>
        /// 组织机构号
        /// </summary>
        public Guid OrganizationUnitId { get; set; }
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; set; }

        public Guid SuperiorId { get; set; }
    }
}
