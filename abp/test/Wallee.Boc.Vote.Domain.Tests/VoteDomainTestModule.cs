using Wallee.Boc.Vote.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wallee.Boc.Vote;

[DependsOn(
    typeof(VoteEntityFrameworkCoreTestModule)
    )]
public class VoteDomainTestModule : AbpModule
{

}
