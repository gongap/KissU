using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart
{
    [DependsOn(
        typeof(QuickStartDomainSharedModule)
        )]
    public class QuickStartDomainModule : AbpModule
    {

    }
}
