using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.Clients;
using KissU.Modules.IdentityServer.Domain.Devices;
using KissU.Modules.IdentityServer.Domain.Grants;
using KissU.Modules.IdentityServer.Domain.IdentityResources;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using ApiResource = KissU.Modules.IdentityServer.Domain.ApiResources.ApiResource;

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
