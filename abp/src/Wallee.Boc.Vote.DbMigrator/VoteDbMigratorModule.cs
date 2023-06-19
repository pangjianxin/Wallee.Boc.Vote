using Wallee.Boc.Vote.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Wallee.Boc.Vote.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VoteEntityFrameworkCoreModule),
    typeof(VoteApplicationContractsModule)
    )]
public class VoteDbMigratorModule : AbpModule
{

}
