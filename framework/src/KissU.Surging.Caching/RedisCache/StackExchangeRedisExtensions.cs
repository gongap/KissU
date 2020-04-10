using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace KissU.Surging.Caching.RedisCache
{
    /// <summary>
    /// StackExchangeRedisExtensions.
    /// </summary>
    public static class StackExchangeRedisExtensions
    {
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T Get<T>(this IDatabase cache, string key)
        {
            return Deserialize<T>(cache.StringGet(key));
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        public static void Remove(this IDatabase cache, string key)
        {
            cache.KeyDelete(key);
        }

        /// <summary>
        /// remove as an asynchronous operation.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        public static async Task RemoveAsync(this IDatabase cache, string key)
        {
            await cache.KeyDeleteAsync(key);
        }

        /// <summary>
        /// get many as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="cacheKeys">The cache keys.</param>
        /// <returns>Task&lt;IDictionary&lt;System.String, T&gt;&gt;.</returns>
        public static async Task<IDictionary<string, T>> GetManyAsync<T>(this IDatabase cache,
            IEnumerable<string> cacheKeys)
        {
            var arrayKeys = cacheKeys.ToArray();
            var result = new Dictionary<string, T>();
            var keys = new RedisKey[cacheKeys.Count()];
            for (var i = 0; i < arrayKeys.Count(); i++)
            {
                keys[i] = arrayKeys[i];
            }

            var values = await cache.StringGetAsync(keys);
            for (var i = 0; i < values.Length; i++)
            {
                result.Add(keys[i], Deserialize<T>(values[i]));
            }

            return result;
        }

        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="cacheKeys">The cache keys.</param>
        /// <returns>IDictionary&lt;System.String, T&gt;.</returns>
        public static IDictionary<string, T> GetMany<T>(this IDatabase cache, IEnumerable<string> cacheKeys)
        {
            var arrayKeys = cacheKeys.ToArray();
            var result = new Dictionary<string, T>();
            var keys = new RedisKey[cacheKeys.Count()];
            for (var i = 0; i < arrayKeys.Count(); i++)
            {
                keys[i] = arrayKeys[i];
            }

            var values = cache.StringGet(keys);
            for (var i = 0; i < values.Length; i++)
            {
                result.Add(keys[i], Deserialize<T>(values[i]));
            }

            return result;
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public static async Task<T> GetAsync<T>(this IDatabase cache, string key)
        {
            return Deserialize<T>(await cache.StringGetAsync(key));
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public static object Get(this IDatabase cache, string key)
        {
            return Deserialize<object>(cache.StringGet(key));
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        public static async Task<object> GetAsync(this IDatabase cache, string key)
        {
            return Deserialize<object>(await cache.StringGetAsync(key));
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set(this IDatabase cache, string key, object value)
        {
            cache.StringSet(key, Serialize(value));
        }

        /// <summary>
        /// set as an asynchronous operation.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static async Task SetAsync(this IDatabase cache, string key, object value)
        {
            await cache.StringSetAsync(key, Serialize(value));
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        public static void Set(this IDatabase cache, string key, object value, TimeSpan timeSpan)
        {
            cache.StringSet(key, Serialize(value), timeSpan);
        }

        /// <summary>
        /// set as an asynchronous operation.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        public static async Task SetAsync(this IDatabase cache, string key, object value, TimeSpan timeSpan)
        {
            await cache.StringSetAsync(key, Serialize(value), timeSpan);
        }


        private static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                var objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        private static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(stream))
            {
                var result = (T) binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}