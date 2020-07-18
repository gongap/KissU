using KissU.Modules.FeatureManagement.Application.Contracts;
using KissU.Modules.FeatureManagement.Domain.Shared.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Services.FeatureManagement.Contract
{
    [DependsOn(
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class FeatureManagementServiceContractsModule : AbpModule
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
        }
    }
}