using KissU.Modularity;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// 身份服务模块
    /// </summary>
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule)
    )]
    public class IdentityServiceContractsModule : AbpModule, IBusinessModule
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}