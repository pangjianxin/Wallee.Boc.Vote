using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Minio;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Wallee.Boc.Vote;

[DependsOn(
    typeof(VoteDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(VoteApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpBlobStoringMinioModule)
    )]
public class VoteApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var config = context.Services.GetConfiguration();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<VoteApplicationModule>();
        });

        ConfigureMinio(config);
    }

    private void ConfigureMinio(IConfiguration configuration)
    {
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(config =>
            {
                config.UseMinio(option =>
                {
                    option.EndPoint = configuration["Blob:Minio:EndPoint"];
                    option.AccessKey = configuration["Blob:Minio:AccessKey"];
                    option.SecretKey = configuration["Blob:Minio:SecretKey"];
                    option.CreateBucketIfNotExists = true;
                });
            });
        });
    }
}
