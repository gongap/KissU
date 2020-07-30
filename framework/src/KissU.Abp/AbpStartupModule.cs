using Volo.Abp.Castle;
using Volo.Abp.Modularity;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpCastleCoreModule))]
    public class AbpStartupModule : Volo.Abp.Modularity.AbpModule
    {
    }
}