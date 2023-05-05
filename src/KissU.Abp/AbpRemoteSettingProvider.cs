using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;
using KissU.Abp.AppConfigurations;
using KissU.CPlatform.Routing;
using KissU.Dependency;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissU.Abp
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(ISettingProvider))]
    public class AbpRemoteSettingProvider : SettingProvider, ISettingProvider
    {
        private readonly CPlatformContainer _cPlatformContainer;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly ILogger<AbpRemotePermissionChecker> _logger;
        private readonly ICachedAppConfigurationClient _configurationClient;

        public AbpRemoteSettingProvider(CPlatformContainer cPlatformContainer,
            IServiceRouteProvider serviceRouteProvider,
            ILogger<AbpRemotePermissionChecker> logger, ISettingDefinitionManager settingDefinitionManager,
            ISettingEncryptionService settingEncryptionService,
            ISettingValueProviderManager settingValueProviderManager,
            ICachedAppConfigurationClient configurationClient) : base(settingDefinitionManager,
            settingEncryptionService, settingValueProviderManager)
        {
            _cPlatformContainer = cPlatformContainer;
            _serviceRouteProvider = serviceRouteProvider;
            _logger = logger;
            _configurationClient = configurationClient;
        }

        public new async Task<string> GetOrNullAsync(string name)
        {
            if (IsLocalExecute())
            {
                return await base.GetOrNullAsync(name);
            }

            try
            {
                var configuration = await _configurationClient.GetSettingConfigAsync();
                if (configuration != null)
                {
                    return configuration.Values.GetOrDefault(name);
                }

                var routePath = $"{AppConfig.Options.SettingRoutePath}/getornull";
                var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var parameters = new Dictionary<string, object> { { "name", name } };
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<string>(parameters, routePath);
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            return await base.GetOrNullAsync(name);
        }

        public new async Task<List<SettingValue>> GetAllAsync(string[] names)
        {
            if (IsLocalExecute())
            {
                return await base.GetAllAsync(names);
            }

            try
            {
                var configuration = await _configurationClient.GetSettingConfigAsync();
                if (configuration != null)
                {
                    return names.Select(x => new SettingValue(x, configuration.Values.GetOrDefault(x))).ToList();
                }

                var routePath = $"{AppConfig.Options.SettingRoutePath}/getall";
                var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var parameters = new Dictionary<string, object> { { "names", string.Join(",", names) } };
                    var result = await ServiceLocator.GetService<IServiceProxyProvider>()
                        .Invoke<List<SettingValue>>(parameters, routePath);
                    return result ?? new List<SettingValue>();
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            return await base.GetAllAsync(names);
        }

        public new async Task<List<SettingValue>> GetAllAsync()
        {
            if (IsLocalExecute())
            {
                return await base.GetAllAsync();
            }

            var configuration = await _configurationClient.GetSettingConfigAsync();
            if (configuration != null)
            {
                return configuration
                    .Values.Select(s => new SettingValue(s.Key, s.Value))
                    .ToList();
            }

            return await GetAllAsync(Array.Empty<string>());
        }

        private bool IsLocalExecute()
        {
            if (AppConfig.Options.IsEnabledRemoteSettingProvider && _cPlatformContainer.GetInstances<ISettingStore>() is NullSettingStore)
            {
                return false;
            }

            return true;
        }
    }
}
