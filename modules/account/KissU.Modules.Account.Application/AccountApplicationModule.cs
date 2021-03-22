using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.Application
{
    [DependsOn(typeof(AccountApplicationContractsModule), typeof(AbpAccountApplicationModule)
    )]
    public class AccountApplicationModule : AbpModule
    {
    }
}