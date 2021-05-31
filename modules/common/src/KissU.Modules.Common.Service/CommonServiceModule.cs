using KissU.Modularity;
using KissU.Modules.Common.Service.Contracts;
using Volo.Abp.Modularity;

namespace KissU.Modules.Common.Service
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