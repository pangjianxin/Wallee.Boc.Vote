using Volo.Abp.Modularity;

namespace Wallee.Boc.Vote;

[DependsOn(
    typeof(VoteApplicationModule),
    typeof(VoteDomainTestModule)
    )]
public class VoteApplicationTestModule : AbpModule
{

}
