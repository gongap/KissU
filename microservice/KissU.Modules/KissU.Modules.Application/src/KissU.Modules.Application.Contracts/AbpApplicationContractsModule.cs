using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.Application
{
    [DependsOn(
        typeof(AbpDddApplicationModule)
    )]
    public class AbpApplicationContractsModule : AbpModule
    {
    }
}