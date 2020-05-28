using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.Identity.DbMigrations.Data
{
    /* This is used if database provider does't define
     * IIdentityDbSchemaMigrator implementation.
     */
    public class NullDbSchemaMigrator : DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}