using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.SimpleStateChecking;
using KissU.Abp.AppConfigurations;
using KissU.CPlatform.Routing;
using KissU.Dependency;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KissU.Abp
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(IPermissionChecker))]
    public class AbpRemotePermissionChecker : PermissionChecker, IPermissionChecker
    {
        private readonly CPlatformContainer _cPlatformContainer;
        private readonly ICachedAppConfigurationClient _configurationClient;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly ILogger<AbpRemotePermissionChecker> _logger;

        public AbpRemotePermissionChecker(CPlatformContainer cPlatformContainer,
            ICachedAppConfigurationClient configurationClient,
            IServiceRouteProvider serviceRouteProvider,
            ILogger<AbpRemotePermissionChecker> logger, ICurrentPrincipalAccessor principalAccessor,
            IPermissionDefinitionManager permissionDefinitionManager, ICurrentTenant currentTenant,
            IPermissionValueProviderManager permissionValueProviderManager,
            ISimpleStateCheckerManager<PermissionDefinition> stateCheckerManager)
            : base(principalAccessor, permissionDefinitionManager, currentTenant, permissionValueProviderManager,
                stateCheckerManager)
        {
            _cPlatformContainer = cPlatformContainer;
            _configurationClient = configurationClient;
            _serviceRouteProvider = serviceRouteProvider;
            _logger = logger;
        }

        public new async Task<bool> IsGrantedAsync(string name)
        {
            var routePath = $"{AppConfig.Options.PermissionRoutePath}/isgranted";
            if (IsLocalExecute())
            {
                return await base.IsGrantedAsync(name);
            }

            try
            {
                var configuration = await _configurationClient.GetAuthConfigAsync();
                if (configuration != null)
                {
                    return configuration.GrantedPolicies.ContainsKey(name);
                }

                var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var result = PermissionGrantResult.Undefined;
                    var parameters = new Dictionary<string, object> { { "names", name } };
                    var grantResult = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<Dictionary<string, PermissionGrantResult>>(parameters, routePath);
                    grantResult?.TryGetValue(name, out result);
                    return result == PermissionGrantResult.Granted;
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            return await base.IsGrantedAsync(name);
        }

        public new async Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name)
        {
            /* This provider always works for the current principal. */
            return await IsGrantedAsync(name);
        }

        public new async Task<MultiplePermissionGrantResult> IsGrantedAsync(string[] names)
        {
            if (IsLocalExecute())
            {
                return await base.IsGrantedAsync(names);
            }

            try
            {
                var result = new MultiplePermissionGrantResult();
                var configuration = await _configurationClient.GetAuthConfigAsync();
                if (configuration != null)
                {
                    foreach (var name in names)
                    {
                        result.Result.Add(name,
                            configuration.GrantedPolicies.ContainsKey(name)
                                ? PermissionGrantResult.Granted
                                : PermissionGrantResult.Undefined);
                    }

                    return result;
                }

                var routePath = $"{AppConfig.Options.PermissionRoutePath}/isgranted";
                var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var parameters = new Dictionary<string, object> { { "names", string.Join(",", names) } };
                    var grantResult = await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<Dictionary<string, PermissionGrantResult>>(parameters, routePath);
                    if (grantResult != null)
                    {
                        foreach (var name in names)
                        {
                            if (grantResult.TryGetValue(name, out var item))
                            {
                                result.Result.Add(name, item);
                            }
                        }
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            return await base.IsGrantedAsync(names);
        }

        public new async Task<MultiplePermissionGrantResult> IsGrantedAsync(ClaimsPrincipal claimsPrincipal,string[] names)
        {
            /* This provider always works for the current principal. */
            return await IsGrantedAsync(names);
        }

        private bool IsLocalExecute()
        {
            if (AppConfig.Options.IsEnabledRemotePermissionChecker && _cPlatformContainer.GetInstances<IPermissionStore>() is NullPermissionStore)
            {
                return false;
            }

            return true;
        }
    }
}
