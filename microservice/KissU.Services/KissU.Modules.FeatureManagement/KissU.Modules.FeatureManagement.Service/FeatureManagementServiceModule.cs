using KissU.Abp.Autofac;
using KissU.Modules.FeatureManagement.Application;
using KissU.Modules.FeatureManagement.Domain.Shared.Localization;
using KissU.Modules.FeatureManagement.EntityFrameworkCore;
using KissU.Modules.FeatureManagement.Service.Contracts;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.Service
{
    [DependsOn(
        typeof(FeatureManagementServiceContractsModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class FeatureManagementServiceModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpFeatureManagementResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}