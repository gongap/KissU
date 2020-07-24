using KissU.Abp;
using KissU.Services.Application.Contract;
using Volo.Abp.Modularity;

namespace KissU.Modules.Application.Service
{
    [DependsOn(
        typeof(AppServiceContractsModule),
        typeof(AbpApplicationModule)
    )]
    public class AppServiceModule : AbpModule, IAbpStartupModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}