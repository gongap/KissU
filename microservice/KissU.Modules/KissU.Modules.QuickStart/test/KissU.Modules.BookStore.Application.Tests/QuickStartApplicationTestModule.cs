using Volo.Abp.Modularity;

namespace KissU.Modules.QuickStart
{
    [DependsOn(
        typeof(QuickStartApplicationModule),
        typeof(QuickStartDomainTestModule)
        )]
    public class QuickStartApplicationTestModule : AbpModule
    {

    }
}
