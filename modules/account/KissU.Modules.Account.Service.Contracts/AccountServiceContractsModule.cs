using KissU.Modularity;
using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 账号服务模块
    /// Implements the <see cref="KissU.Modularity.AbpBusinessModule" />
    /// </summary>
    /// <seealso cref="KissU.Modularity.AbpBusinessModule" />
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpUiModule)
        )]
    public class AccountServiceContractsModule : AbpBusinessModule
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
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