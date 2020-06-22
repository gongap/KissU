using KissU.Abp.Autofac;
using KissU.Modules.Blogging.Application;
using KissU.Modules.Blogging.Domain.Shared.Localization;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Service
{
    [DependsOn(
        typeof(BloggingApplicationModule),
        typeof(BloggingEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpBloggingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BloggingResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}