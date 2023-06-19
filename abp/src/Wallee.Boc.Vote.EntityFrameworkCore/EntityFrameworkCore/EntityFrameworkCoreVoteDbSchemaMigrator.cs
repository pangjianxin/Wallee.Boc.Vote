using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wallee.Boc.Vote.Data;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.EntityFrameworkCore;

public class EntityFrameworkCoreVoteDbSchemaMigrator
    : IVoteDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreVoteDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the VoteDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<VoteDbContext>()
            .Database
            .MigrateAsync();
    }
}
