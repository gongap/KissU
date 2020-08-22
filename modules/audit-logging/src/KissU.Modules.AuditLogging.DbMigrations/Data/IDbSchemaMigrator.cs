using System.Threading.Tasks;

namespace KissU.Modules.AuditLogging.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
