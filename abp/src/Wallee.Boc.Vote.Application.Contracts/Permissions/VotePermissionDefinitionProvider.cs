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
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VoteResource>(name);
    }
}
