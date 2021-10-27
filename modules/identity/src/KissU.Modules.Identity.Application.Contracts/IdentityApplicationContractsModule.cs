using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.Application.Contracts
{
    [DependsOn(typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpAccountApplicationContractsModule)
    )]
    public class IdentityApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}