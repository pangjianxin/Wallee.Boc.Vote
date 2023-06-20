using Volo.Abp.ObjectExtending;

namespace Wallee.Boc.Vote.OrganizationUnits.Dtos
{
    public class OrganizationUnitUpdateDto : ExtensibleObject
    {
        public string DisplayName { get; set; } = null!;
    }
}
