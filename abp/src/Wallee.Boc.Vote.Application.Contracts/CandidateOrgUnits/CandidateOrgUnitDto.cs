using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitDto : AuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        /// <summary>
        /// 组织机构id
        /// </summary>
        public Guid OrganizationUnitId { get; private set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OrganName { get; set; } = null!;
        /// <summary>
        /// 部门号
        /// </summary>
        public string OrganCode { get; set; } = null!;
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; set; }
        /// <summary>
        /// 分管领导用户Id
        /// </summary>
        public Guid Superior { get; private set; }
        /// <summary>
        /// 分管领导名称
        /// </summary>
        public string SuperiorName { get; private set; } = null!;
        public string ConcurrencyStamp { get; set; } = null!;
    }
}
