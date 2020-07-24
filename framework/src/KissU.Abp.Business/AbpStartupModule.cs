using KissU.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Abp
{
    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class AbpStartupModule : AbpModule
    {
    }
}