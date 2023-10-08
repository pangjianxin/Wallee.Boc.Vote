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
        public Guid OrganizationUnitId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OrganName { get; set; } = default!;
        /// <summary>
        /// 部门号
        /// </summary>
        public string OrganCode { get; set; } = default!;
        /// <summary>
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; set; }
        /// <summary>
        /// 分管领导用户Id
        /// </summary>
        public Guid Superior { get; set; }
        /// <summary>
        /// 分管领导名称
        /// </summary>
        public string SuperiorName { get; set; } = default!;
        public bool IsActive { get; set; }
        public string ConcurrencyStamp { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
