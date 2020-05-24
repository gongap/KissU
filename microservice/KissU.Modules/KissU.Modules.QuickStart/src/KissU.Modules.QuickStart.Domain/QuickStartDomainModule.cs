using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart
{
    [DependsOn(
        typeof(QuickStartDomainSharedModule),
        typeof(AbpDddDomainModule)
        )]
    public class QuickStartDomainModule : AbpModule
    {
    }
}
