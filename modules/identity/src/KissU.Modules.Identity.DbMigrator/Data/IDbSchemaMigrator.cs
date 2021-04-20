using System.Threading.Tasks;

namespace KissU.Modules.Identity.DbMigrator.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
