using System.Threading.Tasks;

namespace KissU.Modules.FeatureManagement.DbMigrator.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
