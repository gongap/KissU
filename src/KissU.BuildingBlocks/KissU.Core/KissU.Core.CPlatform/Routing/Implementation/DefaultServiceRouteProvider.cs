using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Transport.Implementation;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Logging;

namespace KissU.Core.CPlatform.Routing.Implementation
{
    /// <summary>
    /// 默认服务路由提供者.
    /// Implements the <see cref="IServiceRouteProvider" />
    /// </summary>
    /// <seealso cref="IServiceRouteProvider" />
    public class DefaultServiceRouteProvider : IServiceRouteProvider
    {
        private readonly ConcurrentDictionary<string, ServiceRoute> _concurrent =
            new ConcurrentDictionary<string, ServiceRoute>();

        private readonly List<ServiceRoute> _localRoutes = new List<ServiceRoute>();
        private readonly ILogger<DefaultServiceRouteProvider> _logger;
        private readonly IServiceEntryManager _serviceEntryManager;

        private readonly ConcurrentDictionary<string, ServiceRoute> _serviceRoute =
            new ConcurrentDictionary<string, ServiceRoute>();

        private readonly IServiceRouteManager _serviceRouteManager;
        private readonly IServiceTokenGenerator _serviceTokenGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceRouteProvider" /> class.
        /// </summary>
        /// <param name="serviceRouteManager">The service route manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        /// <param name="serviceTokenGenerator">The service token generator.</param>
        public DefaultServiceRouteProvider(IServiceRouteManager serviceRouteManager,
            ILogger<DefaultServiceRouteProvider> logger, IServiceEntryManager serviceEntryManager,
            IServiceTokenGenerator serviceTokenGenerator)
        {
            _serviceRouteManager = serviceRouteManager;
            serviceRouteManager.Changed += ServiceRouteManager_Removed;
            serviceRouteManager.Removed += ServiceRouteManager_Removed;
            serviceRouteManager.Created += ServiceRouteManager_Add;
            _serviceEntryManager = serviceEntryManager;
            _serviceTokenGenerator = serviceTokenGenerator;
            _logger = logger;
        }

        /// <summary>
        /// 根据服务id找到相关服务信息
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Task&lt;ServiceRoute&gt;.</returns>
        public async Task<ServiceRoute> Locate(string serviceId)
        {
            _concurrent.TryGetValue(serviceId, out var route);
            if (route == null)
            {
                var routes = await _serviceRouteManager.GetRoutesAsync();
                route = routes.FirstOrDefault(i => i.ServiceDescriptor.Id == serviceId);
                if (route == null)
                {
                    if (_logger.IsEnabled(LogLevel.Warning))
                    {
                        _logger.LogWarning($"根据服务id：{serviceId}，找不到相关服务信息。");
                    }
                }
                else
                {
                    _concurrent.GetOrAdd(serviceId, route);
                }
            }

            return route;
        }

        /// <summary>
        /// 通过路径正则表达式获取本地路由.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ValueTask&lt;ServiceRoute&gt;.</returns>
        public ValueTask<ServiceRoute> GetLocalRouteByPathRegex(string path)
        {
            var addess = NetUtils.GetHostAddress();

            if (_localRoutes.Count == 0)
            {
                _localRoutes.AddRange(_serviceEntryManager.GetEntries().Select(i =>
                {
                    i.Descriptor.Token = _serviceTokenGenerator.GetToken();
                    return new ServiceRoute
                    {
                        Address = new[] { addess },
                        ServiceDescriptor = i.Descriptor,
                    };
                }).ToList());
            }

            path = path.ToLower();
            _serviceRoute.TryGetValue(path, out var route);
            if (route == null)
            {
                return new ValueTask<ServiceRoute>(GetRouteByPathRegexAsync(_localRoutes, path));
            }

            return new ValueTask<ServiceRoute>(route);
        }

        /// <summary>
        /// 根据服务路由路径获取路由信息
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ValueTask&lt;ServiceRoute&gt;.</returns>
        public ValueTask<ServiceRoute> GetRouteByPath(string path)
        {
            _serviceRoute.TryGetValue(path.ToLower(), out var route);
            if (route == null)
            {
                return new ValueTask<ServiceRoute>(GetRouteByPathAsync(path));
            }

            return new ValueTask<ServiceRoute>(route);
        }

        /// <summary>
        /// 通过路径正则表达式获取路线.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ValueTask&lt;ServiceRoute&gt;.</returns>
        public async ValueTask<ServiceRoute> GetRouteByPathRegex(string path)
        {
            path = path.ToLower();
            _serviceRoute.TryGetValue(path, out var route);
            if (route == null)
            {
                var routes = await _serviceRouteManager.GetRoutesAsync();
                return await GetRouteByPathRegexAsync(routes, path);
            }

            return route;
        }

        /// <summary>
        /// 根据服务路由路径找到相关服务信息
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Task&lt;ServiceRoute&gt;.</returns>
        public async Task<ServiceRoute> SearchRoute(string path)
        {
            return await SearchRouteAsync(path);
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="processorTime">The processor time.</param>
        /// <returns>Task.</returns>
        public async Task RegisterRoutes(decimal processorTime)
        {
            var addess = NetUtils.GetHostAddress();
            addess.ProcessorTime = processorTime;
            RpcContext.GetContext().SetAttachment("Host", addess);
            var addressDescriptors = _serviceEntryManager.GetEntries().Select(i =>
            {
                i.Descriptor.Token = _serviceTokenGenerator.GetToken();
                return new ServiceRoute
                {
                    Address = new[] { addess },
                    ServiceDescriptor = i.Descriptor,
                };
            }).ToList();
            await _serviceRouteManager.SetRoutesAsync(addressDescriptors);
        }

        private static string GetCacheKey(ServiceDescriptor descriptor)
        {
            return descriptor.Id;
        }

        private void ServiceRouteManager_Removed(object sender, ServiceRouteEventArgs e)
        {
            var key = GetCacheKey(e.Route.ServiceDescriptor);
            ServiceRoute value;
            _concurrent.TryRemove(key, out value);
            _serviceRoute.TryRemove(e.Route.ServiceDescriptor.RoutePath, out value);
        }

        private void ServiceRouteManager_Add(object sender, ServiceRouteEventArgs e)
        {
            var key = GetCacheKey(e.Route.ServiceDescriptor);
            _concurrent.GetOrAdd(key, e.Route);
            _serviceRoute.GetOrAdd(e.Route.ServiceDescriptor.RoutePath, e.Route);
        }

        private async Task<ServiceRoute> SearchRouteAsync(string path)
        {
            var routes = await _serviceRouteManager.GetRoutesAsync();
            var route = routes.FirstOrDefault(i => string.Compare(i.ServiceDescriptor.RoutePath, path, true) == 0);
            if (route == null)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogWarning($"根据服务路由路径：{path}，找不到相关服务信息。");
                }
            }
            else
            {
                _serviceRoute.GetOrAdd(path, route);
            }

            return route;
        }

        private async Task<ServiceRoute> GetRouteByPathAsync(string path)
        {
            var routes = await _serviceRouteManager.GetRoutesAsync();
            var route = routes.FirstOrDefault(i =>
                string.Compare(i.ServiceDescriptor.RoutePath, path, true) == 0 &&
                !i.ServiceDescriptor.GetMetadata<bool>("IsOverload"));
            if (route == null)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogWarning($"根据服务路由路径：{path}，找不到相关服务信息。");
                }
            }
            else
            {
                _serviceRoute.GetOrAdd(path, route);
            }

            return route;
        }

        private async Task<ServiceRoute> GetRouteByPathRegexAsync(IEnumerable<ServiceRoute> routes, string path)
        {
            var pattern = "/{.*?}";

            var route = routes.FirstOrDefault(i =>
            {
                var routePath = Regex.Replace(i.ServiceDescriptor.RoutePath, pattern, string.Empty);
                var newPath = path.Replace(routePath, string.Empty);
                return (newPath.StartsWith("/") || newPath.Length == 0) &&
                       i.ServiceDescriptor.RoutePath.Split("/").Length == path.Split("/").Length &&
                       !i.ServiceDescriptor.GetMetadata<bool>("IsOverload");
            });

            if (route == null)
            {
                if (_logger.IsEnabled(LogLevel.Warning))
                {
                    _logger.LogWarning($"根据服务路由路径：{path}，找不到相关服务信息。");
                }
            }
            else if (!Regex.IsMatch(route.ServiceDescriptor.RoutePath, pattern))
            {
                _serviceRoute.GetOrAdd(path, route);
            }

            return await Task.FromResult(route);
        }
    }
}