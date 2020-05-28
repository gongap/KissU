using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using KissU.Modules.IdentityServer.ApiResources;
using KissU.Modules.IdentityServer.Clients;
using KissU.Modules.IdentityServer.Devices;
using KissU.Modules.IdentityServer.Grants;
using KissU.Modules.IdentityServer.IdentityResources;
using Volo.Abp.Modularity;

namespace KissU.Modules.IdentityServer.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class AbpIdentityServerEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<IIdentityServerBuilder>(
                builder =>
                {
                    builder.AddAbpStores();
                }
            );
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityServerDbContext>(options =>
            {
                options.AddDefaultRepositories<IIdentityServerDbContext>();

                options.AddRepository<Client, ClientRepository>();
                options.AddRepository<ApiResource, ApiResourceRepository>();
                options.AddRepository<IdentityResource, IdentityResourceRepository>();
                options.AddRepository<PersistedGrant, PersistentGrantRepository>();
                options.AddRepository<DeviceFlowCodes, DeviceFlowCodesRepository>();
            });
        }
    }
}
