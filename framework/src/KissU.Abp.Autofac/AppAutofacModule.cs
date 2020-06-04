using Volo.Abp.Castle;
using Volo.Abp.Modularity;

namespace KissU.Abp.Autofac
{
    [DependsOn(typeof(AbpCastleCoreModule))]
    public class AppAutofacModule : AbpModule
    {

    }
}
