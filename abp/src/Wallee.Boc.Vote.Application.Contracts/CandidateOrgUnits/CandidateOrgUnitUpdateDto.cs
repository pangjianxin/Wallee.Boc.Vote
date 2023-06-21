using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitUpdateDto : IHasConcurrencyStamp
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
        /// 部门类别
        /// </summary>
        public CandidateOrgUnitCategory Category { get; set; }
        public string ConcurrencyStamp { get; set; } = null!;
    }
}
