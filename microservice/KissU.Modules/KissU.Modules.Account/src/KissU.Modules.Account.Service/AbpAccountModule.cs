using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule))]
    public class AbpAccountModule : AbpModule
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