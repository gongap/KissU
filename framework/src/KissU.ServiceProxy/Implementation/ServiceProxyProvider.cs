using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.CPlatform.Routing;
using KissU.Dependency;
using KissU.Extensions;

namespace KissU.ServiceProxy.Implementation
{
    /// <summary>
    /// ServiceProxyProvider.
    /// Implements the <see cref="IServiceProxyProvider" />
    /// </summary>
    /// <seealso cref="IServiceProxyProvider" />
    public class ServiceProxyProvider : IServiceProxyProvider
    {
        private readonly CPlatformContainer _serviceProvider;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProxyProvider" /> class.
        /// </summary>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public ServiceProxyProvider(IServiceRouteProvider serviceRouteProvider
            , CPlatformContainer serviceProvider)
        {
            _serviceRouteProvider = serviceRouteProvider;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="routePath">The route path.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath)
        {
            var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
            T result = default;
            if (parameters.ContainsKey("serviceKey"))
            {
                var serviceKey = parameters["serviceKey"].ToString();
                var proxy = ServiceResolver.Current.GetService<RemoteServiceProxy>(serviceKey);
                if (proxy == null)
                {
                    proxy = new RemoteServiceProxy(serviceKey, _serviceProvider);
                    ServiceResolver.Current.Register(serviceKey, proxy);
                }

                result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id);
            }
            else
            {
                var proxy = ServiceResolver.Current.GetService<RemoteServiceProxy>();
                if (proxy == null)
                {
                    proxy = new RemoteServiceProxy(null, _serviceProvider);
                    ServiceResolver.Current.Register(null, proxy);
                }

                result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id);
            }

            return result;
        }

        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="routePath">The route path.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath, string serviceKey)
        {
            var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
            var result = default(T);
            if (!string.IsNullOrEmpty(serviceKey))
            {
                var proxy = ServiceResolver.Current.GetService<RemoteServiceProxy>(serviceKey);
                if (proxy == null)
                {
                    proxy = new RemoteServiceProxy(serviceKey, _serviceProvider);
                    ServiceResolver.Current.Register(serviceKey, proxy);
                }

                result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id);
            }
            else
            {
                var proxy = ServiceResolver.Current.GetService<RemoteServiceProxy>();
                if (proxy == null)
                {
                    proxy = new RemoteServiceProxy(null, _serviceProvider);
                    ServiceResolver.Current.Register(null, proxy);
                }

                result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id);
            }

            return result;
        }
    }
}