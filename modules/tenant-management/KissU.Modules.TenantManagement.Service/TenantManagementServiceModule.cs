using KissU.Modularity;
using KissU.Modules.TenantManagement.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace KissU.Modules.TenantManagement.Service
{
    [DependsOn(
        typeof(TenantManagementServiceContractsModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule)
    )]
    public class TenantManagementServiceModule : AbpBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}