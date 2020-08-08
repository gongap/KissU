using KissU.Modules.Users.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace KissU.Modules.Users.MongoDB
{
    [DependsOn(
        typeof(AbpUsersDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpUsersMongoDbModule : AbpModule
    {
        
    }
}
