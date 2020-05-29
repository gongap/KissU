using KissU.Modules.Blogging.Domain.Shared;
using KissU.Modules.Blogging.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace KissU.Modules.Blogging.Application.Contracts
{
    [DependsOn(typeof(BloggingDomainSharedModule))]
    public class BloggingApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BloggingApplicationContractsModule>();
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BloggingResource>()
                    .AddVirtualJson("Volo/Blogging/Localization/Resources/Blogging/ApplicationContracts");
            });
        }
    }
}
