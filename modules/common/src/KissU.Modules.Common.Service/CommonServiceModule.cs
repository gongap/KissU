using KissU.Modularity;
using KissU.Modules.Account.Service.Contracts;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Service
{
    [DependsOn(
        typeof(CommonServiceContractsModule)
        )]
    public class CommonServiceModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}