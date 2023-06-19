using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.Data;

/* This is used if database provider does't define
 * IVoteDbSchemaMigrator implementation.
 */
public class NullVoteDbSchemaMigrator : IVoteDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
