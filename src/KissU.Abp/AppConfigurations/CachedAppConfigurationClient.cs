using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.AspNetCore.Mvc.MultiTenancy;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Transport.Implementation;
using KissU.Dependency;
using KissU.ServiceProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Abp.AppConfigurations
{
    [ExposeServices(
        typeof(CachedAppConfigurationClient),
        typeof(ICachedAppConfigurationClient)
    )]
    public class CachedAppConfigurationClient : ICachedAppConfigurationClient, Volo.Abp.DependencyInjection.ITransientDependency
    {
        public static ConcurrentDictionary<string,List<string>> CacheKeys  { get; } = new();
        public static readonly string SettingCacheKey = "Setting";
        public static readonly string AuthCacheKey = "Auth";
        public static readonly string FeatureCacheKey = "Feature";

        protected IServiceRouteProvider ServiceRouteProvider { get; }
        protected IHttpContextAccessor HttpContextAccessor { get; }
        protected ICurrentUser CurrentUser { get; }
        protected IDistributedCache<AppConfigurationDto> ConfigurationCache { get; }
        protected IDistributedCache<ApplicationSettingConfigurationDto> SettingCache { get; }
        protected IDistributedCache<ApplicationAuthConfigurationDto> AuthCache { get; }
        protected IDistributedCache<ApplicationFeatureConfigurationDto> FeatureCache { get; }
        protected ILogger<CachedAppConfigurationClient> Logger { get; }

        public CachedAppConfigurationClient(
            IDistributedCache<AppConfigurationDto> configurationCache,
            IDistributedCache<ApplicationSettingConfigurationDto> settingCache,
            IDistributedCache<ApplicationAuthConfigurationDto> authCache,
            IDistributedCache<ApplicationFeatureConfigurationDto> featureCache,
            ICurrentUser currentUser,
            IHttpContextAccessor httpContextAccessor,
            IServiceRouteProvider serviceRouteProvider,
            ILogger<CachedAppConfigurationClient> logger)
        {
            ConfigurationCache = configurationCache;
            SettingCache = settingCache;
            AuthCache = authCache;
            FeatureCache = featureCache;
            CurrentUser = currentUser;
            HttpContextAccessor = httpContextAccessor;
            ServiceRouteProvider = serviceRouteProvider;
            Logger = logger;
        }

        public async Task InitializeAsync()
        {
            await GetAsync();
        }

        public async Task<AppConfigurationDto> GetAsync()
        {
            var cacheKey = CreateCacheKey();
            if (RpcContext.GetContext().GetAttachment(cacheKey) is AppConfigurationDto configuration)
            {
                return configuration;
            }

            configuration = await ConfigurationCache.GetOrAddAsync(
                cacheKey,
                async () =>
                {
                    return new AppConfigurationDto
                    {
                        Timing = await GetTimingConfigAsync(),
                        Clock = await GetClockConfigAsync(),
                        MultiTenancy = await GetMultiTenancyAsync(),
                        CurrentTenant = await GetCurrentTenantAsync(),
                        CurrentUser =  await GetCurrentUserAsync(),
                    };
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(AppConfig.Options.AppConfigurationCacheExpiration),
                }
            );

            configuration.Setting = await GetSettingConfigAsync();
            configuration.Auth = await GetAuthConfigAsync();
            configuration.Features = await GetFeaturesConfigAsync();

            RpcContext.GetContext().SetAttachment(cacheKey, configuration);
            return configuration;
        }

        /// <summary>
        /// 获取应用设置配置
        /// </summary>
        /// <returns>应用设置配置</returns>
        public async Task<ApplicationSettingConfigurationDto> GetSettingConfigAsync()
        {
            var cacheKey = CreateCacheKey(SettingCacheKey);
            if (RpcContext.GetContext().GetAttachment(cacheKey) is ApplicationSettingConfigurationDto configuration)
            {
                return configuration;
            }

            configuration = await SettingCache.GetOrAddAsync(
                cacheKey,
                async () =>
                {
                    try
                    {
                        var routePath = AppConfig.Options.SettingConfigRoutePath;
                        var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                        if (serviceRoute != null)
                        {
                            return await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<ApplicationSettingConfigurationDto>(null, routePath);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.LogWarning(e.Message);
                    }

                    return new ApplicationSettingConfigurationDto();
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(AppConfig.Options.AppConfigurationCacheExpiration),
                }
            );

            RpcContext.GetContext().SetAttachment(cacheKey, configuration);

            return configuration ?? new ApplicationSettingConfigurationDto();
        }

        /// <summary>
        /// 获取应用权限配置
        /// </summary>
        /// <returns>应用权限配置</returns>
        public async Task<ApplicationAuthConfigurationDto> GetAuthConfigAsync()
        {
            var cacheKey = CreateCacheKey(AuthCacheKey);
            if (RpcContext.GetContext().GetAttachment(cacheKey) is ApplicationAuthConfigurationDto configuration)
            {
                return configuration;
            }

            configuration = await AuthCache.GetOrAddAsync(
                cacheKey,
                async () =>
                {
                    try
                    {
                        var routePath = AppConfig.Options.AuthConfigRoutePath;
                        var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                        if (serviceRoute != null)
                        {
                            return await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<ApplicationAuthConfigurationDto>(null, routePath);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.LogWarning(e.Message);
                    }

                    return new ApplicationAuthConfigurationDto();
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(AppConfig.Options.AppConfigurationCacheExpiration),
                }
            );

            RpcContext.GetContext().SetAttachment(cacheKey, configuration);

            return configuration ?? new ApplicationAuthConfigurationDto();
        }

        /// <summary>
        /// 获取应用功能配置
        /// </summary>
        /// <returns>应用功能配置</returns>
        public async Task<ApplicationFeatureConfigurationDto> GetFeaturesConfigAsync()
        {
            var cacheKey = CreateCacheKey(FeatureCacheKey);
            if (RpcContext.GetContext().GetAttachment(cacheKey) is ApplicationFeatureConfigurationDto configuration)
            {
                return configuration;
            }

            configuration = await FeatureCache.GetOrAddAsync(
                cacheKey,
                async () =>
                {
                    try
                    {
                        var routePath = AppConfig.Options.FeatureConfigRoutePath;
                        var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                        if (serviceRoute != null)
                        {
                            return  await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<ApplicationFeatureConfigurationDto>(null, routePath);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.LogWarning(e.Message);
                    }

                    return new ApplicationFeatureConfigurationDto();
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(AppConfig.Options.AppConfigurationCacheExpiration),
                }
            );

            RpcContext.GetContext().SetAttachment(cacheKey, configuration);

            return configuration ?? new ApplicationFeatureConfigurationDto();
        }

        /// <summary>
        /// 获取时区配置
        /// </summary>
        /// <returns>时区配置</returns>
        protected async Task<TimingDto> GetTimingConfigAsync()
        {
            try
            {
                var routePath = AppConfig.Options.TimingConfigRoutePath;
                var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<TimingDto>(null, routePath);
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning(e.Message);
            }

            return new TimingDto();
        }

        /// <summary>
        /// 获取时钟配置
        /// </summary>
        /// <returns>时钟配置</returns>
        protected async Task<ClockDto> GetClockConfigAsync()
        {
            try
            {
                var routePath = AppConfig.Options.ClockConfigRoutePath;
                var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<ClockDto>(null, routePath);
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning(e.Message);
            }

            return new ClockDto();
        }

        /// <summary>
        /// 获取多租户配置
        /// </summary>
        /// <returns>租户配置</returns>
        protected async Task<MultiTenancyInfoDto> GetMultiTenancyAsync()
        {
            try
            {
                var routePath = AppConfig.Options.MultiTenancyRoutePath;
                var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<MultiTenancyInfoDto>(null, routePath);
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning(e.Message);
            }

            return new MultiTenancyInfoDto();
        }

        /// <summary>
        /// 获取当前租户信息
        /// </summary>
        /// <returns>当前租户信息</returns>
        private async Task<CurrentTenantDto> GetCurrentTenantAsync()
        {
            try
            {
                var routePath = AppConfig.Options.CurrentTenantRoutePath;
                var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<CurrentTenantDto>(null, routePath);
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning(e.Message);
            }

            return new CurrentTenantDto();
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns>当前用户信息</returns>
        private async Task<CurrentUserDto> GetCurrentUserAsync()
        {
            try
            {
                var routePath = AppConfig.Options.CurrentUserRoutePath;
                var serviceRoute = await ServiceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<CurrentUserDto>(null, routePath);
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning(e.Message);
            }

            return new CurrentUserDto();
        }

        protected virtual string CreateCacheKey(string config = null)
        {
            var userKey = CurrentUser.Id?.ToString("N") ?? "Anonymous";
            var cacheKey = $"AppConfiguration{(config == null ? "" : $"_{config}")}_{userKey}";
            if (config != null)
            {
                var cacheKeys = CacheKeys.GetOrAdd(config, () => new List<string>());
                cacheKeys.AddIfNotContains(cacheKey);
            }

            return cacheKey;
        }
    }
}
