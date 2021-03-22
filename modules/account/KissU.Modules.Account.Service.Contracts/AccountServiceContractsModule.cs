using KissU.Modularity;
using KissU.Modules.Account.Application.Contracts;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 账号服务模块
    /// </summary>
    [DependsOn(
        typeof(AccountApplicationContractsModule)
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