using System.Threading.Tasks;

namespace KissU.Modules.TenantManagement.DbMigrations.Data
{
    public interface DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
