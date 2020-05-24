using System.Threading.Tasks;

namespace KissU.Modules.QuickStart.Data
{
    public interface IQuickStartDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
