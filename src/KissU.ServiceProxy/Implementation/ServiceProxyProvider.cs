using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.CPlatform.Routing;
using KissU.Dependency;

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
        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath, bool? decodeJOject = null)
        {
            var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
            T result = default(T);
            if (serviceRoute != null)
            {
                if (parameters != null && parameters.ContainsKey("serviceKey"))
                {
                    var serviceKey = parameters["serviceKey"].ToString();
                    var proxy = new RemoteServiceProxy(serviceKey, _serviceProvider);
                    result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id, decodeJOject);

                }
                else
                {
                    var proxy = new RemoteServiceProxy(null, _serviceProvider);
                    result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id, decodeJOject);
                }
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
        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath, string serviceKey, bool? decodeJOject = null)
        {
            var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
            T result = default(T);
            if (serviceRoute != null)
            {
                if (!string.IsNullOrEmpty(serviceKey))
                {
                    var proxy = new RemoteServiceProxy(serviceKey, _serviceProvider);
                    result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id, decodeJOject);
                }
                else
                {
                    var proxy = new RemoteServiceProxy(null, _serviceProvider);
                    result = await proxy.Invoke<T>(parameters, serviceRoute.ServiceDescriptor.Id, decodeJOject);
                }
            }

            return result;
        }
    }
}