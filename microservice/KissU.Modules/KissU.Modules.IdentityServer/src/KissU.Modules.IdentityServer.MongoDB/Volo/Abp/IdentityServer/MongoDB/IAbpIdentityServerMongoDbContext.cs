using MongoDB.Driver;
using Volo.Abp.Data;
using KissU.Modules.IdentityServer.Clients;
using KissU.Modules.IdentityServer.Devices;
using KissU.Modules.IdentityServer.Grants;
using KissU.Modules.IdentityServer.IdentityResources;
using Volo.Abp.MongoDB;
using ApiResource = KissU.Modules.IdentityServer.ApiResources.ApiResource;

namespace KissU.Modules.IdentityServer.MongoDB
{
    [ConnectionStringName(AbpIdentityServerDbProperties.ConnectionStringName)]
    public interface IAbpIdentityServerMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<ApiResource> ApiResources { get; }

        IMongoCollection<Client> Clients { get; }

        IMongoCollection<IdentityResource> IdentityResources { get; }

        IMongoCollection<PersistedGrant> PersistedGrants { get; }

        IMongoCollection<DeviceFlowCodes> DeviceFlowCodes { get; }
    }
}
