using KissU.Abp.Autofac;
using KissU.Modules.QuickStart.EntityFrameworkCore;
using KissU.Modules.QuickStart.Settings;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace KissU.Modules.QuickStart.Service
{
    [DependsOn(
        typeof(QuickStartApplicationModule),
        typeof(QuickStartEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpQuickStartModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSettingOptions>(options =>
            {
                options.DefinitionProviders.Add<QuickStartSettingDefinitionProvider>();
            });

            context.Services.AddAutoMapperObjectMapper<AbpQuickStartModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpQuickStartAutoMapperProfile>(validate: true);
            });
        }
    }
}