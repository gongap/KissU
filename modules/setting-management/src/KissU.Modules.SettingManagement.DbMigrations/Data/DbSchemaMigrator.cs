using System.Threading.Tasks;

namespace KissU.Modules.SettingManagement.DbMigrations.Data
{
    public interface DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
