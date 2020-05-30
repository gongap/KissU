using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.ApiResources;
using KissU.Modules.IdentityServer.Domain.Clients;
using KissU.Modules.IdentityServer.Domain.Devices;
using KissU.Modules.IdentityServer.Domain.Grants;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using IdentityResource = KissU.Modules.IdentityServer.Domain.IdentityResources.IdentityResource;

namespace KissU.Modules.IdentityServer.MongoDB
{
    [ConnectionStringName(AbpIdentityServerDbProperties.ConnectionStringName)]
    public class AbpIdentityServerMongoDbContext : AbpMongoDbContext, IAbpIdentityServerMongoDbContext
    {
        public IMongoCollection<ApiResource> ApiResources => Collection<ApiResource>();

        public IMongoCollection<Client> Clients => Collection<Client>();

        public IMongoCollection<IdentityResource> IdentityResources => Collection<IdentityResource>();

        public IMongoCollection<PersistedGrant> PersistedGrants => Collection<PersistedGrant>();

        public IMongoCollection<DeviceFlowCodes> DeviceFlowCodes => Collection<DeviceFlowCodes>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureIdentityServer();
        }
    }
}
