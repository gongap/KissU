using System;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.ApiResources;
using KissU.Modules.IdentityServer.Domain.Clients;
using KissU.Modules.IdentityServer.Domain.Devices;
using KissU.Modules.IdentityServer.Domain.Grants;
using KissU.Modules.IdentityServer.Domain.IdentityResources;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace KissU.Modules.IdentityServer.MongoDB
{
    public static class AbpIdentityServerMongoDbContextExtensions
    {
        public static void ConfigureIdentityServer(
            this IMongoModelBuilder builder,
            Action<IdentityServerMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new IdentityServerMongoModelBuilderConfigurationOptions(
                AbpIdentityServerDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<ApiResource>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ApiResources";
            });

            builder.Entity<Client>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Clients";
            });
            builder.Entity<IdentityResource>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "IdentityResources";
            });

            builder.Entity<PersistedGrant>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "PersistedGrants";
            });

            builder.Entity<DeviceFlowCodes>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "DeviceFlowCodes";
            });
        }
    }
}
