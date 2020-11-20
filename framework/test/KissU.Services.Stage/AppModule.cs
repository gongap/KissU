using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Services
{
    [DependsOn(typeof(AbpAutofacModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}