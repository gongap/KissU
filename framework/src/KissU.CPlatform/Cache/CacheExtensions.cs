using System;
using System.Threading.Tasks;

namespace KissU.CPlatform.Cache
{
    /// <summary>
    /// Class CacheExtensions.
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// get or add as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>Task&lt;TValue&gt;.</returns>
        public static Task<TValue> GetOrAddAsync<TValue>(this ICacheProvider cacheProvider, string cacheKey, Func<Task<TValue>> factory)
        {
            return GetOrAddAsync(cacheProvider, cacheKey, 10, factory);
        }

        /// <summary>
        /// get or add as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="numOfMinutes">The number of minutes.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>Task&lt;TValue&gt;.</returns>
        public static async Task<TValue> GetOrAddAsync<TValue>(this ICacheProvider cacheProvider, string cacheKey, long numOfMinutes, Func<Task<TValue>> factory)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                return default;
            }

            var obj = cacheProvider.Get<TValue>(cacheKey);
            if (obj != null)
            {
                return obj;
            }

            if (factory != null)
            {
                obj = await factory();
                if (obj != null)
                {
                    cacheProvider.AddAsync(cacheKey, obj, numOfMinutes);
                }
            }

            return obj;
        }
    }
}
