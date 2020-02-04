using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;

namespace KissU.Core.Consul.Internal
{
    /// <summary>
    /// Interface IConsulClientProvider
    /// </summary>
    public interface IConsulClientProvider
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns>ValueTask&lt;ConsulClient&gt;.</returns>
        ValueTask<ConsulClient> GetClient();

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns>ValueTask&lt;IEnumerable&lt;ConsulClient&gt;&gt;.</returns>
        ValueTask<IEnumerable<ConsulClient>> GetClients();

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <returns>ValueTask.</returns>
        ValueTask Check();
    }
}