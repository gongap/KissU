using System.Threading.Tasks;

namespace KissU.Modules.AuditLogging.DbMigrations.Data
{
    public interface DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
