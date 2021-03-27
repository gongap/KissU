using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Security;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule)
        ,typeof(AbpSecurityModule)
        ,typeof(AbpLocalizationModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                foreach (var resource in options.Resources)
                {
                    resource.Value.DefaultCultureName = "zh-Hans";
                }
            });
        }
    }
}