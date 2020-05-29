using KissU.Abp.Autofac;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}