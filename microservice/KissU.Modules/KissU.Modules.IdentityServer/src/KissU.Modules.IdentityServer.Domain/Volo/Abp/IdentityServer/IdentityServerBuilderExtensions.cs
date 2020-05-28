using IdentityServer4.Stores;
using Microsoft.Extensions.DependencyInjection;
using KissU.Modules.IdentityServer.Clients;
using KissU.Modules.IdentityServer.Devices;
using KissU.Modules.IdentityServer.Grants;

namespace KissU.Modules.IdentityServer
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAbpStores(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();
            builder.Services.AddTransient<IDeviceFlowStore, DeviceFlowStore>();

            return builder
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                .AddCorsPolicyService<AbpCorsPolicyService>();
        }
    }
}