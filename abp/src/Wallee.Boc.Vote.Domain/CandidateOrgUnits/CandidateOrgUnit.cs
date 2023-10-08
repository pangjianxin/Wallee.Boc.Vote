using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    /// <summary>
    /// 待评价部门列表
    /// </summary>
    public class CandidateOrgUnit : AuditedAggregateRoot<Guid>
    {
        public CandidateOrgUnit(
            Guid id,
            Guid organizationUnitId,
            string organCode,
            string organName,
            string description,
            Guid superior,
            string superiorName,
            CandidateOrgUnitCategory category) : base(id)
        {
            OrganizationUnitId = organizationUnitId;
            OrganCode = organCode;
            OrganName = organName;
            Description = description;
            Superior = superior;
            SuperiorName = superiorName;
            IsActive = true;
            Category = category;
        }

        public Guid OrganizationUnitId { get; private set; }
        /// <summary>
        /// 部门号
        /// </summary>
        public string OrganCode { get; private set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OrganName { get; private set; }
        /// <summary>
        /// 机构重点工作描述
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 是否参与此次评测
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; private set; }
        /// <summary>
        /// 分管领导用户Id
        /// </summary>
        public Guid Superior { get; private set; }
        /// <summary>
        /// 分管领导名称
        /// </summary>
        public string SuperiorName { get; private set; }

        public void SetSuperior(Guid superior, string superiorName)
        {
            Superior = superior;
            SuperiorName = superiorName;
        }

        public void SetOrgUnitInfo(Guid organizationUnitId, string organCode, string organName, string description)
        {
            Description = description;
            OrganizationUnitId = organizationUnitId;
            OrganCode = organCode;
            OrganName = organName;
        }

        public void SetCategory(CandidateOrgUnitCategory category)
        {
            Category = category;
        }

        public void SetActive(bool active)
        {
            IsActive = active;
        }
    }
}
