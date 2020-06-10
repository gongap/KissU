using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Identity.Application;
using Volo.Abp.Modularity;
namespace KissU.Modules.Account.Application
{
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpIdentityApplicationModule)
    )]
    public class AbpAccountApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}