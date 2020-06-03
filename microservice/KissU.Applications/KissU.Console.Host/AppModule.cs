using KissU.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Console.Host
{
    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class AppModule : AbpModule
    {
    }
}