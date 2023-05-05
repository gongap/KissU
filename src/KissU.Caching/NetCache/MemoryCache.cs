using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using KissU.Infrastructure.Core.Exceptions;
using KissU.Infrastructure.Core.Helpers;

namespace KissU.Caching.NetCache
{
    /// <summary>
    /// MemoryCache.
    /// </summary>
    public class MemoryCache
    {
        private const int taskInterval = 5;

        private static readonly ConcurrentDictionary<string, Tuple<string, object, DateTime>> cache =
            new ConcurrentDictionary<string, Tuple<string, object, DateTime>>();

        static MemoryCache()
        {
            try
            {
                GCThreadProvider.AddThread(Collect);
            }
            catch (Exception err)
            {
                throw new CacheException(err.Message, err);
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public static int Count => cache.Count;

        /// <summary>
        /// 获得一个Cache对象
        /// </summary>
        /// <param name="key">标识</param>
        /// <returns>System.Object.</returns>
        public static object Get(string key)
        {
            CheckHelper.CheckCondition(() => string.IsNullOrEmpty(key), "key");
            object result;
            if (Contains(key, out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Gets the specified keys.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns>IDictionary&lt;System.String, T&gt;.</returns>
        public static IDictionary<string, T> Get<T>(IEnumerable<string> keys)
        {
            if (keys == null)
            {
                return new Dictionary<string, T>();
            }

            var dictionary = new Dictionary<string, T>();
            var enumerator = keys.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var obj2 = Get(current);
                if (obj2 is T)
                {
                    dictionary.Add(current, (T) obj2);
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Gets the cache try parse.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool GetCacheTryParse(string key, out object obj)
        {
            CheckHelper.CheckCondition(() => string.IsNullOrEmpty(key), "key");
            obj = Get(key);
            return obj != null;
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T Get<T>(string key)
        {
            CheckHelper.CheckCondition(() => string.IsNullOrEmpty(key), "key");
            var obj2 = Get(key);
            if (obj2 is T)
            {
                return (T) obj2;
            }

            return default;
        }

        /// <summary>
        /// 是否存在缓存
        /// </summary>
        /// <param name="key">标识</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.</returns>
        public static bool Contains(string key, out object value)
        {
            var isSuccess = false;
            Tuple<string, object, DateTime> item;
            value = null;
            if (cache.TryGetValue(key, out item))
            {
                value = item.Item2;
                isSuccess = item.Item3 > DateTime.Now;
            }

            return isSuccess;
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="cacheSecond">The cache second.</param>
        public static void Set(string key, object value, double cacheSecond)
        {
            var cacheTime = DateTime.Now.AddSeconds(cacheSecond);
            var cacheValue = new Tuple<string, object, DateTime>(key, value, cacheTime);
            cache.AddOrUpdate(key, cacheValue, (v, oldValue) => cacheValue);
        }

        /// <summary>
        /// Removes the by pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public static void RemoveByPattern(string pattern)
        {
            var enumerator = cache.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (enumerator.MoveNext())
            {
                var input = enumerator.Current.Key;
                if (regex.IsMatch(input))
                {
                    Remove(input);
                }
            }
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Remove(string key)
        {
            Tuple<string, object, DateTime> item;
            cache.TryRemove(key, out item);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public static void Dispose()
        {
            cache.Clear();
        }

        private static void Collect(object threadID)
        {
            while (true)
            {
                try
                {
                    var cacheValues = cache.Values;
                    cacheValues = cacheValues.OrderBy(p => p.Item3).ToList();
                    foreach (var cacheValue in cacheValues)
                    {
                        if ((cacheValue.Item3 - DateTime.Now).Seconds <= 0)
                        {
                            Tuple<string, object, DateTime> item;
                            cache.TryRemove(cacheValue.Item1, out item);
                        }
                    }

                    Thread.Sleep(taskInterval * 60 * 1000);
                }
                catch
                {
                    Dispose();
                    GCThreadProvider.AddThread(Collect);
                }
            }
        }
    }
}