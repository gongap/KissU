using KissU.Abp.Autofac;
using KissU.Modules.TenantManagement.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}