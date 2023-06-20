using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Wallee.Boc.Vote.Authorization.Permissions;

namespace Wallee.Boc.Vote.PermissionManagement
{
    public class OrganizationUnitPermissionManagementProvider : PermissionManagementProvider
    {
        public override string Name => OrganizationUnitPermissionValueProvider.ProviderName;

        public OrganizationUnitPermissionManagementProvider(
            IPermissionGrantRepository permissionGrantRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
            : base(
                permissionGrantRepository,
                guidGenerator,
                currentTenant)
        {
        }
    }
}
