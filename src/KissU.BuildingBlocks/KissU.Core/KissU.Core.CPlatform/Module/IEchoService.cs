using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Core.CPlatform.Support.Attributes;

namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 回声服务
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("")]
    public interface IEchoService : IServiceKey
    {
        /// <summary>
        /// 定位指定的键的路由地址.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="routePath">The route path.</param>
        /// <returns>Task&lt;IpAddressModel&gt;.</returns>
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task<IpAddressModel> Locate(string key, string routePath);
    }
}