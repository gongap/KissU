using KissU.Abp.Autofac;
using KissU.Modules.PermissionManagement.DbMigrations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EntityFrameworkCoreDbMigrationsModule)
    )]
    public class DbMigratorModule : AbpModule
    {
    }
}