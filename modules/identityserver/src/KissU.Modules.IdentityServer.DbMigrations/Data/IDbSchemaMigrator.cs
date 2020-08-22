using System.Threading.Tasks;

namespace KissU.Modules.IdentityServer.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
