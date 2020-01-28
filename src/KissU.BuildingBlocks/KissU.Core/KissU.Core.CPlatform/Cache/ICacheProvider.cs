using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Cache
{
    /// <summary>
    /// 缓存提供程序
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// 连接缓存终结点
        /// </summary>
        /// <param name="endpoint">终结点</param>
        /// <returns>是否连接成功</returns>
        Task<bool> ConnectionAsync(CacheEndpoint endpoint);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Add(string key, object value);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void AddAsync(string key, object value);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="defaultExpire">if set to <c>true</c> [default expire].</param>
        void Add(string key, object value, bool defaultExpire);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="defaultExpire">if set to <c>true</c> [default expire].</param>
        void AddAsync(string key, object value, bool defaultExpire);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="numOfMinutes">The number of minutes.</param>
        void Add(string key, object value, long numOfMinutes);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="numOfMinutes">The number of minutes.</param>
        void AddAsync(string key, object value, long numOfMinutes);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        void Add(string key, object value, TimeSpan timeSpan);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        void AddAsync(string key, object value, TimeSpan timeSpan);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns>IDictionary&lt;System.String, T&gt;.</returns>
        IDictionary<string, T> Get<T>(IEnumerable<string> keys);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns>Task&lt;IDictionary&lt;System.String, T&gt;&gt;.</returns>
        Task<IDictionary<string, T>> GetAsync<T>(IEnumerable<string> keys);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        object Get(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        Task<object> GetAsync(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        T Get<T>(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool GetCacheTryParse(string key, out object obj);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(string key);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">The key.</param>
        void RemoveAsync(string key);

        /// <summary>
        /// 默认的过期时间.
        /// </summary>
        /// <value>The default expire time.</value>
        long DefaultExpireTime { get; set; }

        /// <summary>
        /// 键后缀。
        /// </summary>
        /// <value>The key suffix.</value>
        string KeySuffix { get; set; }
    }
}