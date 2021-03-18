using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                foreach (var resource in options.Resources)
                {
                    resource.Value.DefaultCultureName = "zh-Hant";
                }
            });
        }
    }
}