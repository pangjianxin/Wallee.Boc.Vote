using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.Vote.OrganizationUnits.Dtos
{
    public class OrganizationUnitDto : ExtensibleAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
    }
}
