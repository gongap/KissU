using KissU.Modules.Blogging.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Application.Contracts.Shared
{
    [DependsOn(typeof(BloggingDomainSharedModule),
        typeof(AbpDddApplicationModule))]
    public class BloggingApplicationContractsSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
