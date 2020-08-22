using System.Threading.Tasks;

namespace KissU.Modules.BackgroundJobs.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
