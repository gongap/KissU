using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace KissU.Modules.Identity.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSettingManagementEntityFrameworkCoreModule)
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