using System.Threading.Tasks;

namespace KissU.Modules.TenantManagement.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
