using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Convertibles;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Runtime.Client;

namespace KissU.Core.ProxyGenerator.Implementation
{
   public class RemoteServiceProxy: ServiceProxyBase
    {
        public RemoteServiceProxy(string serviceKey, CPlatformContainer serviceProvider)
           :this(serviceProvider.GetInstances<IRemoteInvokeService>(),
        serviceProvider.GetInstances<ITypeConvertibleService>(),serviceKey,serviceProvider,
        serviceProvider.GetInstances<IServiceRouteProvider>())
        {
            
        }

        public RemoteServiceProxy(IRemoteInvokeService remoteInvokeService,
            ITypeConvertibleService typeConvertibleService, String serviceKey,
            CPlatformContainer serviceProvider, IServiceRouteProvider serviceRouteProvider
            ):base(remoteInvokeService, typeConvertibleService, serviceKey, serviceProvider)
        {

        }

       public new async Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId)
        {
           return await base.Invoke<T>(parameters, serviceId);
        }

    }
}
