using KissU.Modularity;
using KissU.Modules.Test.Service.Contracts;
using Volo.Abp.Modularity;

namespace KissU.Modules.Test.Service
{
    [DependsOn(
        typeof(TestServiceContractsModule)
        )]
    public class TestServiceModule : AbpModule, IBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}