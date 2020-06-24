using KissU.Abp.Autofac;
using KissU.Modules.TenantManagement.Application;
using KissU.Modules.TenantManagement.Domain.Shared.Localization;
using KissU.Modules.TenantManagement.EntityFrameworkCore;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.Service
{
    [DependsOn(
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpTenantManagementModule : AbpModule
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
                    .Get<AbpTenantManagementResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            }); 

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}