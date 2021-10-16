using KissU.Modularity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Test.Service.Contracts
{
    [DependsOn]
    public class TestServiceContractsModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}