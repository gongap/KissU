using Volo.Abp.Castle;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace KissU.Abp
{
    [DependsOn(typeof(AbpCastleCoreModule), typeof(AbpJsonModule))]
    public class AbpStartupModule : Volo.Abp.Modularity.AbpModule
    {
    }
}