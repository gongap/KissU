using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.HashAlgorithms;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Runtime.Client;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;

namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 回声服务.
    /// Implements the <see cref="ServiceBase" />
    /// Implements the <see cref="IEchoService" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    /// <seealso cref="IEchoService" />
    public class EchoService : ServiceBase, IEchoService
    {
        private readonly IAddressSelector _addressSelector;
        private readonly IHashAlgorithm _hashAlgorithm;
        private readonly IServiceHeartbeatManager _serviceHeartbeatManager;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="EchoService" /> class.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="serviceRouteProvider">The service route provider.</param>
        /// <param name="container">The container.</param>
        /// <param name="serviceHeartbeatManager">The service heartbeat manager.</param>
        public EchoService(IHashAlgorithm hashAlgorithm, IServiceRouteProvider serviceRouteProvider,
            CPlatformContainer container, IServiceHeartbeatManager serviceHeartbeatManager)
        {
            _hashAlgorithm = hashAlgorithm;
            _addressSelector = container.GetInstances<IAddressSelector>(AddressSelectorMode.HashAlgorithm.ToString());
            _serviceRouteProvider = serviceRouteProvider;
            _serviceHeartbeatManager = serviceHeartbeatManager;
        }

        /// <summary>
        /// 定位指定的键的路由地址.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="routePath">The route path.</param>
        /// <returns>Task&lt;IpAddressModel&gt;.</returns>
        public async Task<IpAddressModel> Locate(string key, string routePath)
        {
            var route = await _serviceRouteProvider.SearchRoute(routePath);
            AddressModel result = new IpAddressModel();
            if (route != null)
            {
                result = await _addressSelector.SelectAsync(new AddressSelectContext
                {
                    Address = route.Address,
                    Descriptor = route.ServiceDescriptor,
                    Item = key,
                });
                _serviceHeartbeatManager.AddWhitelist(route.ServiceDescriptor.Id);
            }

            var ipAddress = result as IpAddressModel;
            return ipAddress;
        }
    }
}