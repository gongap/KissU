using KissU.Modules.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.Configuration.Service.Contracts
{
    [DependsOn(typeof(ConfigurationApplicationContractsModule))]
    public class ConfigurationServiceContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}