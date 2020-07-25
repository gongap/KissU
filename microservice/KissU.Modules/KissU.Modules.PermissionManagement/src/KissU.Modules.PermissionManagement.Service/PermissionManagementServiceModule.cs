using KissU.Abp;
using KissU.Abp.Autofac;
using KissU.Abp.Business;
using KissU.Modules.PermissionManagement.Application;
using KissU.Modules.PermissionManagement.Domain.Identity;
using KissU.Modules.PermissionManagement.Domain.IdentityServer;
using KissU.Modules.PermissionManagement.EntityFrameworkCore;
using KissU.Services.PermissionManagement.Contract;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.PermissionManagement.Service
{
    [DependsOn(typeof(PermissionManagementServiceContractsModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class PermissionManagementServiceModule : AbpModule, IAbpStartupModule
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