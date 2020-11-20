using Volo.Abp.Autofac;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace KissU.Abp.Business
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpJsonModule))]
    public class AbpStartupModule : AbpModule
    {
    }
}