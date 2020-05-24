using KissU.Abp.Autofac;
using KissU.Modules.QuickStart.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(QuickStartEntityFrameworkCoreDbMigrationsModule),
        typeof(QuickStartApplicationContractsModule)
        )]
    public class QuickStartDbMigratorModule : AbpModule
    {
        
    }
}
