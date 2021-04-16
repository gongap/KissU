using Volo.Abp.Autofac;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Security;
using Volo.Abp.Validation;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule)
        , typeof(AbpSecurityModule)
        , typeof(AbpValidationModule)
        , typeof(AbpExceptionHandlingModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}