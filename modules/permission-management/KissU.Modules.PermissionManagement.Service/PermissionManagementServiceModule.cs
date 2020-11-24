using KissU.Modularity;
using KissU.Modules.PermissionManagement.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace KissU.Modules.PermissionManagement.Service
{
    [DependsOn(typeof(PermissionManagementServiceContractsModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule)
    )]
    public class PermissionManagementServiceModule : AbpBusunessModule
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