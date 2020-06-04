using KissU.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Console.Host
{
    [DependsOn(
        typeof(AppAutofacModule)
    )]
    public class AppModule : AbpModule
    {
    }
}