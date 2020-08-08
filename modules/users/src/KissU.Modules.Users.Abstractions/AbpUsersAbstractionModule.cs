using Volo.Abp.EventBus;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace KissU.Modules.Users.Abstractions
{
    //TODO: Consider to (somehow) move this to the framework to the same assemblily of ICurrentUser!

    [DependsOn(
        typeof(AbpMultiTenancyModule),
        typeof(AbpEventBusModule)
        )]
    public class AbpUsersAbstractionModule : AbpModule
    {

    }
}
