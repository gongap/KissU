using KissU.Abp.Autofac;
using KissU.Modules.TenantManagement.Application;
using KissU.Modules.TenantManagement.EntityFrameworkCore;
using KissU.Modules.TenantManagement.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.TenantManagement.Service
{
    [DependsOn(
        typeof(TenantManagementServiceContractsModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class TenantManagementServiceModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}