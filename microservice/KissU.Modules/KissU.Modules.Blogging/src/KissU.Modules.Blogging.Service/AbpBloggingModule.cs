using KissU.Abp.Autofac;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Blogging;
using Volo.Blogging.Localization;

namespace KissU.Modules.Blogging.Service
{
    [DependsOn(
        typeof(BloggingApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpBloggingModule : AbpModule
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