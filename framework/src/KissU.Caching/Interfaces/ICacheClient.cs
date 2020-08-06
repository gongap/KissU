using System.Threading.Tasks;
using KissU.CPlatform.Cache;

namespace KissU.Caching.Interfaces
{
    /// <summary>
    /// Interface ICacheClient
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICacheClient<T>
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="connectTimeout">The connect timeout.</param>
        /// <returns>T.</returns>
        T GetClient(CacheEndpoint info, int connectTimeout);

        /// <summary>
        /// Connections the asynchronous.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="connectTimeout">The connect timeout.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ConnectionAsync(CacheEndpoint endpoint, int connectTimeout);
    }
}