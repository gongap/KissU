using KissU.Autofac;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using KissU.Modules.TenantManagement.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.Service
{
    [DependsOn(
        typeof(AbpTenantManagementApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AppAutofacModule)
    )]
    public class AbpTenantManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpTenantManagementResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            }); 

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}