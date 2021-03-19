using KissU.Modularity;
using Volo.Abp.Account;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 账号服务模块
    /// </summary>
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule)
        )]
    public class AccountServiceContractsModule : AbpModule, IBusinessModule
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