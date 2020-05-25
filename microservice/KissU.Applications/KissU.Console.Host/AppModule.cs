using KissU.Abp.Autofac;
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