using KissU.Abp.Autofac;
using KissU.Modules.PermissionManagement.Application;
using KissU.Modules.PermissionManagement.Domain;
using KissU.Modules.PermissionManagement.Domain.Identity;
using KissU.Modules.PermissionManagement.Domain.Shared.Localization;
using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.Service
{
    [DependsOn(
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpPermissionManagementModule : AbpModule
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