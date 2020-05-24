using KissU.Abp.Autofac;
using KissU.Modules.QuickStart.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(QuickStartEntityFrameworkCoreDbMigrationsModule)
    )]
    public class QuickStartDbMigratorModule : AbpModule
    {
    }
}