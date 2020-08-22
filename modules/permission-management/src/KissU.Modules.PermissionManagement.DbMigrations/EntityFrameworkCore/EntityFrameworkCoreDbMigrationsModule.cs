using KissU.Modules.PermissionManagement.DbMigrations.Data;
using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpPermissionManagementEntityFrameworkCoreModule)
    )]
    public class EntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MigrationsDbContext>();
            context.Services.Replace(ServiceDescriptor.Singleton<IDbSchemaMigrator, EntityFrameworkCoreDbSchemaMigrator>());

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}