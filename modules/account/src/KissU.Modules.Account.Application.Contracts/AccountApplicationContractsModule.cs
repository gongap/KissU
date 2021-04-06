using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Account.Application.Contracts
{
    [DependsOn(typeof(AbpIdentityApplicationContractsModule)
    )]
    public class AccountApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}