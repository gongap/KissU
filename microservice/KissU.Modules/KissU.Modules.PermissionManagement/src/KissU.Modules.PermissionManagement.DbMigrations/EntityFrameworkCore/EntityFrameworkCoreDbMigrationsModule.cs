using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}