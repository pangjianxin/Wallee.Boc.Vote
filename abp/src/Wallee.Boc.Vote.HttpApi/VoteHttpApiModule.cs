using Localization.Resources.AbpUi;
using Wallee.Boc.Vote.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.AspNetCore.Mvc;
using Wallee.Boc.Vote.Appraisements;

namespace Wallee.Boc.Vote;

[DependsOn(
    typeof(VoteApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class VoteHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();

        ConfigureAutoApiControllers();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<VoteResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }

    private void ConfigureAutoApiControllers()
    {

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.FormBodyBindingIgnoredTypes.Add(typeof(UploadQrcodeBackgroundDto));
        });
    }
}
