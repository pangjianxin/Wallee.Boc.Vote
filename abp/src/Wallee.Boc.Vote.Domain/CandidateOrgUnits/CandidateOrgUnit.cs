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
            CandidateOrgUnitCategory category) : base(id)
        {
            OrganizationUnitId = organizationUnitId;
            OrganCode = organCode;
            OrganName = organName;
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
        /// 是否参与此次评测
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; private set; }
        /// <summary>
        /// 分管领导名称
        /// </summary>
        public string SuperiorName { get; private set; }
        /// <summary>
        /// 分管领导ehr号
        /// </summary>
        public string SuperiorEhr { get; private set; }

        public void SetSuperior(string superiorName, string superiorEhr)
        {
            SuperiorName = superiorName;
            SuperiorEhr = superiorEhr;
        }

        public void SetOrgUnitInfo(string organCode, string organName)
        {
            OrganCode = organCode;
            OrganName = organName;
        }

        public void SetCategory(CandidateOrgUnitCategory category)
        {
            Category = category;
        }
    }
}
