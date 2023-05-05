using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.MultiTenancy.ConfigurationStore;
using Volo.Abp.Threading;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Transport.Implementation;
using KissU.Dependency;
using KissU.ServiceProxy;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissUtil.Extensions;

namespace KissU.Abp
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(ITenantStore))]
    public class AbpRemoteTenantStore : DefaultTenantStore, ITenantStore
    {
        private readonly ILogger<AbpRemoteTenantStore> _logger;
        private readonly CPlatformContainer _cPlatformContainer;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly IDistributedCache<TenantConfiguration> _cache;

        public AbpRemoteTenantStore(ILogger<AbpRemoteTenantStore> logger,
            CPlatformContainer cPlatformContainer, 
            IServiceRouteProvider serviceRouteProvider,
            IDistributedCache<TenantConfiguration> cache,
            IOptionsMonitor<AbpDefaultTenantStoreOptions> options) : base(options)
        {
            _logger = logger;
            _cPlatformContainer = cPlatformContainer;
            _serviceRouteProvider = serviceRouteProvider;
            _cache = cache;
        }

        public new async Task<TenantConfiguration> FindAsync(string name)
        {
            if (IsLocalExecute(out var tenantStore))
            {
                if (tenantStore != null)
                {
                    return await tenantStore.FindAsync(name);
                }

                return await base.FindAsync(name);
            }

            var cacheKey = CreateCacheKey(name);
            if (RpcContext.GetContext().GetAttachment(cacheKey) is TenantConfiguration tenantConfiguration)
            {
                return tenantConfiguration;
            }

            tenantConfiguration = await _cache.GetOrAddAsync(
                cacheKey,
                async () => { 
                    try
                    {
                        var routePath = $"{AppConfig.Options.TenantRoutePath}/findbyname";
                        var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                        if (serviceRoute != null)
                        {
                            var parameters = new Dictionary<string, object> {{"name", name}};
                            var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<TenantConfiguration>(parameters, routePath);
                            return result ?? new TenantConfiguration();
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning(e.Message);
                    }

                    return await base.FindAsync(name);
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) //TODO: Should be configurable.
                }
            );

            RpcContext.GetContext().SetAttachment(cacheKey, tenantConfiguration);

            return tenantConfiguration;
        }

        public new async Task<TenantConfiguration> FindAsync(Guid id)
        {
            if (IsLocalExecute(out var tenantStore))
            {
                return await tenantStore.FindAsync(id);
            }

            var cacheKey = CreateCacheKey(id);
            if (RpcContext.GetContext().GetAttachment(cacheKey) is TenantConfiguration tenantConfiguration)
            {
                return tenantConfiguration;
            }

            tenantConfiguration = await _cache.GetOrAddAsync(
                cacheKey,
                async () => { 
                    try
                    {
                        var routePath = $"{AppConfig.Options.TenantRoutePath}/findbyid";
                        var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                        if (serviceRoute != null)
                        {
                            var parameters = new Dictionary<string, object> {{"id", id.SafeString()}};
                            var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<TenantConfiguration>(parameters, routePath);
                            return result ?? new TenantConfiguration();
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning(e.Message);
                    }

                    return await base.FindAsync(id);
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(AppConfig.Options.TenantConfigurationCacheExpiration),
                }
            );

            RpcContext.GetContext().SetAttachment(cacheKey, tenantConfiguration);

            return tenantConfiguration;
        }

        public new TenantConfiguration Find(string name)
        {
            return AsyncHelper.RunSync(async () => await FindAsync(name));
        }

        public new TenantConfiguration Find(Guid id)
        {
            return AsyncHelper.RunSync(async () => await FindAsync(id));
        }
        
        private bool IsLocalExecute(out ITenantStore tenantStore)
        {
            var tenantStores = _cPlatformContainer.GetInstances<IEnumerable<ITenantStore>>();
            tenantStore = tenantStores?.FirstOrDefault(x => !(x is AbpRemoteTenantStore || x is DefaultTenantStore));
            if (AppConfig.Options.IsEnabledRemoteTenantStore && tenantStore == null)
            {
                return false;
            }
            
            return true;
        }

        protected virtual string CreateCacheKey(string tenantName)
        {
            return $"AbpRemoteTenantStore_Name_{tenantName}";
        }

        protected virtual string CreateCacheKey(Guid tenantId)
        {
            return $"AbpRemoteTenantStore_Id_{tenantId:N}";
        }
    }
}
