using KissU.Modules.Application;
using Volo.Abp.Modularity;

namespace KissU.Services.Configuration.Contract
{
    [DependsOn(typeof(ConfigurationApplicationContractsModule))]
    public class ConfigurationServiceContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}