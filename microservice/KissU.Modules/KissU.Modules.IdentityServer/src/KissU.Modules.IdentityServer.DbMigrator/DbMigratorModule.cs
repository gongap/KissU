using KissU.Autofac;
using KissU.Modules.IdentityServer.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.IdentityServer.DbMigrator
{
    [DependsOn(
        typeof(AppAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}