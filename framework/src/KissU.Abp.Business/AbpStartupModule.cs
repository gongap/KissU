using KissU.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KissU.Abp.Business
{
    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class AbpStartupModule : AbpModule
    {
    }
}