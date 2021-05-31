using KissU.Modules.Identity.Application.Contracts;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.Application
{
    [DependsOn(typeof(IdentityApplicationContractsModule), typeof(AbpIdentityApplicationModule),
        typeof(AbpAccountApplicationContractsModule), typeof(AbpAccountApplicationModule)
    )]
    public class IdentityServiceModule : AbpModule
    {
    }
}