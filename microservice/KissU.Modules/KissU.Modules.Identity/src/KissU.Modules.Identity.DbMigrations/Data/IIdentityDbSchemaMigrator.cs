using System.Threading.Tasks;

namespace KissU.Modules.Identity.DbMigrations.Data
{
    public interface IIdentityDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
