using Wallee.Boc.Vote.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wallee.Boc.Vote.Permissions;

public class VotePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VotePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(VotePermissions.MyPermission1, L("Permission:MyPermission1"));
        var organizationUnitsPermission = myGroup.AddPermission(VotePermissions.OrganizationUnits.Default, L("Permission:Organization"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.Create, L("Permission:Create"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.Update, L("Permission:Update"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.Delete, L("Permission:Delete"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.ManageRoles, L("Permission:OrganizationUnits:ManageRoles"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.ManageUsers, L("Permission:OrganizationUnits:ManageUsers"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VoteResource>(name);
    }
}
