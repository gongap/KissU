using KissU.Exceptions.Prompts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpAutofacModule))]
    public class AbpStartupModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var abpExceptionPrompt = context.ServiceProvider.GetService<AbpExceptionPrompt>();
            if (abpExceptionPrompt != null)
            {
                ExceptionPrompt.AddPrompt(abpExceptionPrompt);
            }
        }
    }
}