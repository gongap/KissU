using KissU.Modules.Users.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.Users.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpUsersDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class AbpUsersEntityFrameworkCoreModule : AbpModule
    {
        
    }
}
