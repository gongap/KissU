using KissU.Modularity;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpBusunessModule
    {
    }
}