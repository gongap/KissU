using Volo.Abp.Castle;
using Volo.Abp.Modularity;

namespace KissU.Autofac
{
    [DependsOn(typeof(AbpCastleCoreModule))]
    public class AppAutofacModule : AbpModule
    {

    }
}
