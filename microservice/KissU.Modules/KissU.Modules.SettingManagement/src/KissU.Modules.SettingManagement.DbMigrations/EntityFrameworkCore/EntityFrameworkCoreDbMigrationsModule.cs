using KissU.Modules.SettingManagement.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.SettingManagement.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSettingManagementEntityFrameworkCoreModule)
    )]
    public class EntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MigrationsDbContext>();

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}