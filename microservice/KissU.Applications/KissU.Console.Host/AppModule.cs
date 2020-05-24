using KissU.Abp.Autofac;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Console.Host
{
    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class AppModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }
    }
}