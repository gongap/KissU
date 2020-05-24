using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    [DependsOn(
        typeof(QuickStartEntityFrameworkCoreModule)
        )]
    public class QuickStartEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<QuickStartMigrationsDbContext>();
        }
    }
}
