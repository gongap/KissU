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
                options.FileSets.AddEmbedded<BloggingApplicationContractsModule>("KissU.Modules.Blogging.Application.Contracts");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BloggingResource>()
                    .AddVirtualJson("/Localization/Resources/Blogging/ApplicationContracts");
            });
        }
    }
}
