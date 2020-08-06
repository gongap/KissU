using System.Threading.Tasks;
using KissU.Caching.HashAlgorithms;

namespace KissU.Caching.AddressResolvers
{
    /// <summary>
    /// Interface IAddressResolver
    /// </summary>
    public interface IAddressResolver
    {
        /// <summary>
        /// Resolvers the specified cache identifier.
        /// </summary>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>ValueTask&lt;ConsistentHashNode&gt;.</returns>
        ValueTask<ConsistentHashNode> Resolver(string cacheId, string item);
    }
}