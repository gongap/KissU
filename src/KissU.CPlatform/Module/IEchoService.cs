using System.Threading.Tasks;
using KissU.Address;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;

namespace KissU.CPlatform.Module
{
    /// <summary>
    /// EchoService
    /// </summary>
    [ServiceBundle("echo")]
    public interface IEchoService : IServiceKey
    {
        /// <summary>
        /// Locate the route path of the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="routePath">The route path.</param>
        /// <returns>Task&lt;IpAddressModel&gt;.</returns>
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task<IpAddressModel> Locate(string key, string routePath);
    }
}