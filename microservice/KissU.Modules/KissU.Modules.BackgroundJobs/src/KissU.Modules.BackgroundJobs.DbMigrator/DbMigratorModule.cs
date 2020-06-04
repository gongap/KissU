using KissU.Autofac;
using KissU.Modules.BackgroundJobs.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.BackgroundJobs.DbMigrator
{
    [DependsOn(
        typeof(AppAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}