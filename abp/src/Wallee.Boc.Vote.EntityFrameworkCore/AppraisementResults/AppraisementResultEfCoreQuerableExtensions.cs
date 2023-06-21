using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Wallee.Boc.Vote.AppraisementResults;

/// <summary>
/// 
/// </summary>
public static class AppraisementResultEfCoreQuerableExtensions
{
    public static IQueryable<AppraisementResult> IncludeDetails(this IQueryable<AppraisementResult> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }
        return queryable.Include(x => x.Details);// TODO: AbpHelper generated
    }
}
