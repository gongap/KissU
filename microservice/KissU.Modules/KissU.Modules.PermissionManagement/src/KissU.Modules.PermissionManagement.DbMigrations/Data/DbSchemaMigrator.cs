using System.Threading.Tasks;

namespace KissU.Modules.PermissionManagement.DbMigrations.Data
{
    public interface DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
