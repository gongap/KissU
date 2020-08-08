using KissU.Modules.Users.Abstractions;
using KissU.Modules.Users.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace KissU.Modules.Users.Domain
{
    [DependsOn(
        typeof(AbpUsersDomainSharedModule),
        typeof(AbpUsersAbstractionModule),
        typeof(AbpDddDomainModule)
        )]
    public class AbpUsersDomainModule : AbpModule
    {
        
    }
}
