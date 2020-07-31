using KissU.Modules.Application;
using KissU.Modules.Configuration.Service.Contracts;
using KissU.Surging.Abp;
using Volo.Abp.Modularity;

namespace KissU.Modules.Configuration.Service
{
    [DependsOn(
        typeof(ConfigurationServiceContractsModule),
        typeof(ConfigurationApplicationModule)
    )]
    public class ConfigurationServiceModule : Volo.Abp.Modularity.AbpModule, IAbpServiceModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}