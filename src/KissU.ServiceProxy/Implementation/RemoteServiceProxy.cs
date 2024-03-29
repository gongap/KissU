﻿using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Convertibles;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Client;
using KissU.Dependency;

namespace KissU.ServiceProxy.Implementation
{
    /// <summary>
    /// RemoteServiceProxy.
    /// Implements the <see cref="ServiceProxyBase" />
    /// </summary>
    /// <seealso cref="ServiceProxyBase" />
    public class RemoteServiceProxy : ServiceProxyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteServiceProxy" /> class.
        /// </summary>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public RemoteServiceProxy(string serviceKey, CPlatformContainer serviceProvider)
            : this(serviceProvider.GetInstances<IRemoteInvokeService>(),
                serviceProvider.GetInstances<ITypeConvertibleService>(), serviceKey, serviceProvider,
                serviceProvider.GetInstances<IServiceRouteProvider>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteServiceProxy" /> class.
        /// </summary>
        /// <param name="remoteInvokeService">The remote invoke service.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        public RemoteServiceProxy(IRemoteInvokeService remoteInvokeService,
            ITypeConvertibleService typeConvertibleService, string serviceKey,
            CPlatformContainer serviceProvider, IServiceRouteProvider serviceRouteProvider
        ) : base(remoteInvokeService, typeConvertibleService, serviceKey, serviceProvider, serviceRouteProvider)
        {
        }

        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="decodeJOject">decode JOject</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public new async Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId, bool? decodeJOject = null)
        {
            return await base.Invoke<T>(parameters, serviceId, decodeJOject);
        }
    }
}