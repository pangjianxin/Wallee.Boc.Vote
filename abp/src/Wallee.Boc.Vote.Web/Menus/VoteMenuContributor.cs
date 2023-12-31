﻿using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Wallee.Boc.Vote.Localization;
using Wallee.Boc.Vote.MultiTenancy;
using Wallee.Boc.Vote.Permissions;

namespace Wallee.Boc.Vote.Web.Menus;

public class VoteMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<VoteResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                VoteMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
#pragma warning disable CS0162 // 检测到无法访问的代码
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
#pragma warning restore CS0162 // 检测到无法访问的代码
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        if (await context.IsGrantedAsync(VotePermissions.OrganizationUnits.Default))
        {
            var identity = administration.GetMenuItem(IdentityMenuNames.GroupName);
            identity.AddItem(new ApplicationMenuItem(VoteMenus.OrganizationUnit, l["Menu:OrganizationUnit"], "/Identity/OrganizationUnits"));
        }

        administration.Icon = "fas fa-user-cog";
        administration.DisplayName = "系统管理";
        var rulesEngineMenu = new ApplicationMenuItem(VoteMenus.RulesEngine, l["Menu:RulesEngine"], url: "/RulesEngines", icon: "fas fa-cogs", order: 4);
        rulesEngineMenu.AddItem(new ApplicationMenuItem(VoteMenus.RulesEngine_Appraisement_RuleNames, l["Menu:RulesEnging_Appraisement_Rulenames"], url: "/RulesEngines/Appraisements/RuleNames", icon: "fas fa-cogs", order: 1));
        rulesEngineMenu.AddItem(new ApplicationMenuItem(VoteMenus.RulesEngine_AppraisementResult_Rule_Weight, l["Menu:RulesEnging_AppraisementResult_Rule_Weight"], url: "/RulesEngines/AppraisementResults/RuleWeight", icon: "fas fa-cogs", order: 2));
        administration.AddItem(rulesEngineMenu);
    }
}
