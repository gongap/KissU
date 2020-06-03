using KissU.Autofac;
using KissU.Modules.FeatureManagement.Application;
using KissU.Modules.FeatureManagement.DbMigrations.EntityFrameworkCore;
using KissU.Modules.FeatureManagement.Domain.Shared.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.FeatureManagement.Service
{
    [DependsOn(
        typeof(AbpFeatureManagementApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpFeatureManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
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