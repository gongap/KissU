using System.Threading.Tasks;

namespace KissU.Modules.PermissionManagement.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
