using KissU.Modularity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Service.Contracts
{
    [DependsOn]
    public class CommonServiceContractsModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}