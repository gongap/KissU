using KissU.Modularity;
using Localization.Resources.AbpUi;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// 身份服务模块
    /// Implements the <see cref="AbpBusinessModule" />
    /// </summary>
    /// <seealso cref="AbpBusinessModule" />
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class IdentityServiceContractsModule : AbpBusinessModule
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
                    .Get<IdentityResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}