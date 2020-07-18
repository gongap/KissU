using KissU.Services.Application.Contract;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace KissU.Modules.Application.Service
{
    [DependsOn(
        typeof(AppServiceContractsModule)
    )]
    public class AppServiceModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}