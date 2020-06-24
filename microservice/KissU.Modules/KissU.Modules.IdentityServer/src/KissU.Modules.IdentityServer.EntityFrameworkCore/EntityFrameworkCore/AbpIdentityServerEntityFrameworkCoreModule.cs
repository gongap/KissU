using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.ApiResources;
using KissU.Modules.IdentityServer.Domain.Clients;
using KissU.Modules.IdentityServer.Domain.Devices;
using KissU.Modules.IdentityServer.Domain.Grants;
using KissU.Modules.IdentityServer.Domain.IdentityResources;
using KissU.Modules.IdentityServer.EntityFrameworkCore.ApiResources;
using KissU.Modules.IdentityServer.EntityFrameworkCore.Clients;
using KissU.Modules.IdentityServer.EntityFrameworkCore.Devices;
using KissU.Modules.IdentityServer.EntityFrameworkCore.Grants;
using KissU.Modules.IdentityServer.EntityFrameworkCore.IdentityResources;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.IdentityServer.EntityFrameworkCore.EntityFrameworkCore
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

        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
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
