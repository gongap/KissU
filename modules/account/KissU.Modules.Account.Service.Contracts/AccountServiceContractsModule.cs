﻿using KissU.Modularity;
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
    /// </summary>
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpUiModule)
        )]
    public class AccountServiceContractsModule : AbpModule, IBusinessModule
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