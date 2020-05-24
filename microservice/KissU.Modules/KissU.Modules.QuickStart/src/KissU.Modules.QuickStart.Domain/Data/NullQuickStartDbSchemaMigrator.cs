using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.QuickStart.Data
{
    /* This is used if database provider does't define
     * IQuickStartDbSchemaMigrator implementation.
     */
    public class NullQuickStartDbSchemaMigrator : IQuickStartDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}