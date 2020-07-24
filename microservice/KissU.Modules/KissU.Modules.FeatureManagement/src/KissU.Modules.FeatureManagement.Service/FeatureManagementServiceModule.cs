using KissU.Abp;
using KissU.Abp.Autofac;
using KissU.Modules.FeatureManagement.Application;
using KissU.Modules.FeatureManagement.EntityFrameworkCore;
using KissU.Services.FeatureManagement.Contract;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.Service
{
    [DependsOn(
        typeof(FeatureManagementServiceContractsModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class FeatureManagementServiceModule : AbpModule, IAbpStartupModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}