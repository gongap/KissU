using System.Threading.Tasks;

namespace KissU.Modules.TenantManagement.DbMigrator.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
