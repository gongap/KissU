﻿using IdentityServer4.Services;
using IdentityServer4.Stores;
using KissU.Modules.Identity.Domain;
using KissU.Modules.IdentityServer.Domain.ApiResources;
using KissU.Modules.IdentityServer.Domain.Clients;
using KissU.Modules.IdentityServer.Domain.Devices;
using KissU.Modules.IdentityServer.Domain.IdentityResources;
using KissU.Modules.IdentityServer.Domain.Shared;
using KissU.Modules.IdentityServer.Domain.Shared.ApiResources;
using KissU.Modules.IdentityServer.Domain.Shared.Clients;
using KissU.Modules.IdentityServer.Domain.Shared.Devices;
using KissU.Modules.IdentityServer.Domain.Shared.IdentityResources;
using KissU.Modules.IdentityServer.Domain.Shared.ObjectExtending;
using KissU.Modules.IdentityServer.Domain.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Security;
using Volo.Abp.Validation;

namespace KissU.Modules.IdentityServer.Domain
{
    [DependsOn(
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpSecurityModule),
        typeof(AbpCachingModule),
        typeof(AbpValidationModule),
        typeof(AbpBackgroundWorkersModule)
        )]
    public class AbpIdentityServerDomainModule : AbpModule
    {
        public override void ConfigureServices(Volo.Abp.Modularity.ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpIdentityServerDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<IdentityServerAutoMapperProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<ApiResource, ApiResourceEto>(typeof(AbpIdentityServerDomainModule));
                options.EtoMappings.Add<Client, ClientEto>(typeof(AbpIdentityServerDomainModule));
                options.EtoMappings.Add<DeviceFlowCodes, DeviceFlowCodesEto>(typeof(AbpIdentityServerDomainModule));
                options.EtoMappings.Add<IdentityResource, IdentityResourceEto>(typeof(AbpIdentityServerDomainModule));
            });

            AddIdentityServer(context.Services);
        }

        private static void AddIdentityServer(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            var builderOptions = services.ExecutePreConfiguredActions<AbpIdentityServerBuilderOptions>();

            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            });

            if (builderOptions.AddDeveloperSigningCredential)
            {
                identityServerBuilder = identityServerBuilder.AddDeveloperSigningCredential();
            }

            identityServerBuilder.AddAbpIdentityServer(builderOptions);

            services.ExecutePreConfiguredActions(identityServerBuilder);

            if (!services.IsAdded<IPersistedGrantService>())
            {
                services.TryAddSingleton<IPersistedGrantStore, InMemoryPersistedGrantStore>();
            }

            if (!services.IsAdded<IDeviceFlowStore>())
            {
                services.TryAddSingleton<IDeviceFlowStore, InMemoryDeviceFlowStore>();
            }

            if (!services.IsAdded<IClientStore>())
            {
                identityServerBuilder.AddInMemoryClients(configuration.GetSection("IdentityServer:Clients"));
            }

            if (!services.IsAdded<IResourceStore>())
            {
                identityServerBuilder.AddInMemoryApiResources(configuration.GetSection("IdentityServer:ApiResources"));
                identityServerBuilder.AddInMemoryIdentityResources(configuration.GetSection("IdentityServer:IdentityResources"));
            }
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                IdentityServerModuleExtensionConsts.ModuleName,
                IdentityServerModuleExtensionConsts.EntityNames.Client,
                typeof(Client)
            );

            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                IdentityServerModuleExtensionConsts.ModuleName,
                IdentityServerModuleExtensionConsts.EntityNames.IdentityResource,
                typeof(IdentityResource)
            );

            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                IdentityServerModuleExtensionConsts.ModuleName,
                IdentityServerModuleExtensionConsts.EntityNames.ApiResource,
                typeof(ApiResource)
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<TokenCleanupOptions>>().Value;
            if (options.IsCleanupEnabled)
            {
                context.ServiceProvider
                    .GetRequiredService<IBackgroundWorkerManager>()
                    .Add(
                        context.ServiceProvider
                            .GetRequiredService<TokenCleanupBackgroundWorker>()
                    );
            }
        }
    }
}
