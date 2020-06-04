using KissU.Autofac;
using KissU.Modules.AuditLogging.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.AuditLogging.DbMigrator
{
    [DependsOn(
        typeof(AppAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}