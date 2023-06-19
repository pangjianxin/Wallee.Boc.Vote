using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.Web;

[Dependency(ReplaceServices = true)]
public class VoteBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Vote";
}
