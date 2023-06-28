using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.Vote.CandidateOrgUnits
{
    public class CandidateOrgUnitCreateDto : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
}
