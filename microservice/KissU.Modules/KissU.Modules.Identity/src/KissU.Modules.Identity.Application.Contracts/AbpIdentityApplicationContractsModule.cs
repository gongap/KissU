using KissU.Modules.Identity.Domain.Shared;
using KissU.Modules.Users.Abstractions;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Application.Contracts
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpUsersAbstractionModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpDddApplicationModule)
        )]
    public class AbpIdentityApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}