using KissU.Autofac;
using KissU.Modules.Identity.DbMigrations.EntityFrameworkCore;
using KissU.Modules.PermissionManagement.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Identity;

namespace KissU.Modules.PermissionManagement.Service
{
    [DependsOn(
        typeof(AbpPermissionManagementApplicationModule),
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(AppAutofacModule)
    )]
    public class AbpPermissionManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpPermissionManagementResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            }); 
            
            Configure<PermissionManagementOptions>(options =>
            {
                options.ManagementProviders.Add<UserPermissionManagementProvider>();
                options.ManagementProviders.Add<RolePermissionManagementProvider>();
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}