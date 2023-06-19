using Wallee.Boc.Vote.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Wallee.Boc.Vote.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class VotePageModel : AbpPageModel
{
    protected VotePageModel()
    {
        LocalizationResourceType = typeof(VoteResource);
    }
}
