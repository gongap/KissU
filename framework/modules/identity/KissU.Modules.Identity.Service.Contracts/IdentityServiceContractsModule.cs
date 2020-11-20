using KissU.Modularity;
using Localization.Resources.AbpUi;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Modules.Identity.Service.Contracts
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class IdentityServiceContractsModule : AbpBusunessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<IdentityResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}