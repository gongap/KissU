using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI;

namespace KissU.Modules.Application
{
    [DependsOn(
        typeof(ConfigurationApplicationContractsModule),
        typeof(AbpMultiTenancyModule),
        typeof(AbpLocalizationModule),
        typeof(AbpUiModule)
    )]
    public class ConfigurationApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}