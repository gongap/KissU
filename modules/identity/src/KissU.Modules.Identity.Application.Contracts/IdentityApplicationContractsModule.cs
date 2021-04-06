using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KissU.Modules.Identity.Application.Contracts
{
    [DependsOn(typeof(AbpIdentityApplicationContractsModule)
    )]
    public class IdentityApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}