using System.Threading.Tasks;
using KissU.Core.Address;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Support.Attributes;

namespace KissU.Surging.CPlatform.Module
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