using Volo.Abp.DependencyInjection;
using Volo.Abp.Features;
using KissU.Abp.AppConfigurations;
using KissU.CPlatform.Routing;
using KissU.Dependency;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Abp
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(IFeatureChecker))]
    public class AbpRemoteFeatureChecker : FeatureChecker, IFeatureChecker
    {
        private readonly CPlatformContainer _cPlatformContainer;
        private readonly ICachedAppConfigurationClient _configurationClient;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly ILogger<AbpRemotePermissionChecker> _logger;

        public AbpRemoteFeatureChecker(CPlatformContainer cPlatformContainer,
            ICachedAppConfigurationClient configurationClient,
            IServiceRouteProvider serviceRouteProvider,
            ILogger<AbpRemotePermissionChecker> logger, IOptions<AbpFeatureOptions> options,
            IServiceProvider serviceProvider, IFeatureDefinitionManager featureDefinitionManager) : base(options,
            serviceProvider, featureDefinitionManager)
        {
            _cPlatformContainer = cPlatformContainer;
            _configurationClient = configurationClient;
            _serviceRouteProvider = serviceRouteProvider;
            _logger = logger;
        }

        public new async Task<string> GetOrNullAsync(string name)
        {
            if (IsLocalExecute())
            {
                return await base.GetOrNullAsync(name);
            }

            try
            {
                var configuration = await _configurationClient.GetFeaturesConfigAsync();
                if (configuration != null)
                {
                    return configuration.Values.GetOrDefault(name);
                }

                var routePath = $"{AppConfig.Options.FeatureRoutePath}/getornull";
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

        private bool IsLocalExecute()
        {
            if (AppConfig.Options.IsEnabledRemoteFeatureChecker && _cPlatformContainer.GetInstances<IFeatureStore>() is NullFeatureStore)
            {
                return false;
            }

            return true;
        }
    }
}
