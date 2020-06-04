using KissU.Abp.Autofac;
using KissU.Modules.FeatureManagement.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.DbMigrator
{
    [DependsOn(
        typeof(AppAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}