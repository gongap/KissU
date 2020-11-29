using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Modularity
{
    [DependsOn(typeof(AbpAutofacModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}