using System;
using System.Collections.Generic;
using System.Text;
using Wallee.Boc.Vote.Localization;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.Vote;

/* Inherit your application services from this class.
 */
public abstract class VoteAppService : ApplicationService
{
    protected VoteAppService()
    {
        LocalizationResource = typeof(VoteResource);
    }
}
