using KissU.Modules.Blogging.Application.Contracts.Shared;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Application.Contracts
{
    [DependsOn(typeof(BloggingApplicationContractsSharedModule))]
    public class BloggingApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
