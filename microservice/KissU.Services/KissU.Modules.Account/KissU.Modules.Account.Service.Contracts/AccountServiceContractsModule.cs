using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Modules.Account.Service.Contracts
{
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpUiModule)
        )]
    public class AccountServiceContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}