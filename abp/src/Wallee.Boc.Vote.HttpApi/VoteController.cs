using Wallee.Boc.Vote.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wallee.Boc.Vote;

/* Inherit your controllers from this class.
 */
public abstract class VoteController : AbpControllerBase
{
    protected VoteController()
    {
        LocalizationResource = typeof(VoteResource);
    }
}
