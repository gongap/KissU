using KissU.Abp.Autofac;
using KissU.Modules.Application;
using KissU.Modules.Blogging.Application;
using KissU.Modules.Blogging.Domain.Shared.Localization;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Service
{
    [DependsOn(
        typeof(BloggingApplicationModule),
        typeof(AbpApplicationModule),
        typeof(BloggingEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpBloggingModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
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

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}