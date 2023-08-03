using Wallee.Boc.Vote.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity;

namespace Wallee.Boc.Vote.Permissions;

public class VotePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VotePermissions.GroupName, L("Permission:Vote"));

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
        appraisementPermission.AddChild(VotePermissions.Appraisements.QrcodeGeneration, L("Permission:Appraisement:QrcodeGeneration"));

        var appraisementResultPermission = myGroup.AddPermission(VotePermissions.AppraisementResults.Default, L("Permission:AppraisementResults"));
        appraisementResultPermission.AddChild(VotePermissions.AppraisementResults.Create, L("Permission:Create"));
        appraisementResultPermission.AddChild(VotePermissions.AppraisementResults.Update, L("Permission:Update"));
        appraisementResultPermission.AddChild(VotePermissions.AppraisementResults.Delete, L("Permission:Delete"));

        var candidateOrgUnitPermittion = myGroup.AddPermission(VotePermissions.CandidateOrgUnits.Default, L("Permission:CandidateOrgUnits"));
        candidateOrgUnitPermittion.AddChild(VotePermissions.CandidateOrgUnits.Create, L("Permission:Create"));
        candidateOrgUnitPermittion.AddChild(VotePermissions.CandidateOrgUnits.Update, L("Permission:Update"));
        candidateOrgUnitPermittion.AddChild(VotePermissions.CandidateOrgUnits.Delete, L("Permission:Delete"));
        candidateOrgUnitPermittion.AddChild(VotePermissions.CandidateOrgUnits.Appraisement, L("Permission:CandidateOrgUnits:Appraisement"));

        var evaluationContentPermission = myGroup.AddPermission(VotePermissions.EvaluationContents.Default, L("Permission:EvaluationContents"));
        evaluationContentPermission.AddChild(VotePermissions.EvaluationContents.Create, L("Permission:Create"));
        evaluationContentPermission.AddChild(VotePermissions.EvaluationContents.Update, L("Permission:Update"));
        evaluationContentPermission.AddChild(VotePermissions.EvaluationContents.Delete, L("Permission:Delete"));

        var rulesEnginesPermission = myGroup.AddPermission(VotePermissions.RulesEngines.Default, L("Permission:RulesEngines"));
        rulesEnginesPermission.AddChild(VotePermissions.RulesEngines.Create, L("Permission:Create"));
        rulesEnginesPermission.AddChild(VotePermissions.RulesEngines.Update, L("Permission:Update"));
        rulesEnginesPermission.AddChild(VotePermissions.RulesEngines.Delete, L("Permission:Delete"));

    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VoteResource>(name);
    }
}
