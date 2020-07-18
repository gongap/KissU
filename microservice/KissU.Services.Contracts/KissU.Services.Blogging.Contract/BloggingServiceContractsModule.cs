using KissU.Modules.Blogging.Application.Contracts;
using KissU.Modules.Blogging.Domain.Shared.Localization.Blogging;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace KissU.Services.Blogging.Contract
{
    [DependsOn(typeof(BloggingApplicationContractsModule),
        typeof(AbpUiModule))]
    public class BloggingServiceContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BloggingResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}