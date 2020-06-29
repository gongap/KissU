using KissU.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Modules.Application.Service
{
    [DependsOn(
        typeof(AbpConfigurationApplicationModule),
        typeof(AbpAutofacModule)
        )]
    public class AbpApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}