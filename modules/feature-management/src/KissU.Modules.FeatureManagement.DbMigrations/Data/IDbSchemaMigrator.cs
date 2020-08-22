using System.Threading.Tasks;

namespace KissU.Modules.FeatureManagement.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
