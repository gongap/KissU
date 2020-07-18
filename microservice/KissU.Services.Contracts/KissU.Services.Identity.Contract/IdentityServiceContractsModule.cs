using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Domain.Shared.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Services.Identity.Contract
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class IdentityServiceContractsModule : AbpModule
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