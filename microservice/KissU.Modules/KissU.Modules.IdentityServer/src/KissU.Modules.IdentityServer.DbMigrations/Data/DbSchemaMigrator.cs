using System.Threading.Tasks;

namespace KissU.Modules.IdentityServer.DbMigrations.Data
{
    public interface DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
