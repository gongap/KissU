using KissU.Modularity;
using Localization.Resources.AbpUi;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Modules.FeatureManagement.Service.Contracts
{
    [DependsOn(
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class FeatureManagementServiceContractsModule : AbpBusinessModule
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