using KissU.Abp.Autofac;
using KissU.Modules.TenantManagement.Application;
using KissU.Modules.TenantManagement.DbMigrations.EntityFrameworkCore;
using KissU.Modules.TenantManagement.Domain.Shared.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.Service
{
    [DependsOn(
        typeof(AbpTenantManagementApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule)
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