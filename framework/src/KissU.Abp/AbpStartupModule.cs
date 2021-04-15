using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Security;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule)
        ,typeof(AbpSecurityModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}