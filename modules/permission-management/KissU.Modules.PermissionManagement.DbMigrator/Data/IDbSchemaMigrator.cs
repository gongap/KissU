using System.Threading.Tasks;

namespace KissU.Modules.PermissionManagement.DbMigrator.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
