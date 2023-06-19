using System.Threading.Tasks;

namespace Wallee.Boc.Vote.Data;

public interface IVoteDbSchemaMigrator
{
    Task MigrateAsync();
}
