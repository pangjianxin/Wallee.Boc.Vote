using Wallee.Boc.Vote.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity;

namespace Wallee.Boc.Vote.Permissions;

public class VotePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VotePermissions.GroupName);

        //添加用户查询的权限
        PermissionGroupDefinition identityGroup = context.GetGroup(IdentityPermissions.GroupName);
        identityGroup.GetPermissionOrNull(IdentityPermissions.UserLookup.Default).Providers.Add(RolePermissionValueProvider.ProviderName);

        //组织机构权限
        var organizationUnitsPermission = myGroup.AddPermission(VotePermissions.OrganizationUnits.Default, L("Permission:Organization"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.Create, L("Permission:Create"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.Update, L("Permission:Update"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.Delete, L("Permission:Delete"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.ManageRoles, L("Permission:OrganizationUnits:ManageRoles"));
        organizationUnitsPermission.AddChild(VotePermissions.OrganizationUnits.ManageUsers, L("Permission:OrganizationUnits:ManageUsers"));

        var appraisementPermission = myGroup.AddPermission(VotePermissions.Appraisements.Default, L("Permission:Appraisement"));
        appraisementPermission.AddChild(VotePermissions.Appraisements.Create, L("Permission:Create"));
        appraisementPermission.AddChild(VotePermissions.Appraisements.Update, L("Permission:Update"));
        appraisementPermission.AddChild(VotePermissions.Appraisements.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VoteResource>(name);
    }
}
