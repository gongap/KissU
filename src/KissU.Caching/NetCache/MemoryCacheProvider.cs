using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Caching.RedisCache;
using KissU.CPlatform.Cache;
using KissU.ServiceProxy.Interceptors.Implementation.Metadatas;

namespace KissU.Caching.NetCache
{
    /// <summary>
    /// MemoryCacheProvider. This class cannot be inherited.
    /// Implements the <see cref="KissU.CPlatform.Cache.ICacheProvider" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Cache.ICacheProvider" />
    [IdentifyCache(CacheTargetType.MemoryCache)]
    public sealed class MemoryCacheProvider : ICacheProvider
    {
        #region 私有变量

        private string GetKeySuffix(string key)
        {
            return string.IsNullOrEmpty(KeySuffix) ? key : string.Format("_{0}_{1}", KeySuffix, key);
        }

        #endregion

        #region 字段

        /// <summary>
        /// 缓存数据上下文
        /// </summary>
        private readonly Lazy<RedisContext> _context;

        /// <summary>
        /// 默认失效时间
        /// </summary>
        private Lazy<long> _defaultExpireTime;

        /// <summary>
        /// 配置失效时间
        /// </summary>
        private const double ExpireTime = 60D;

        /// <summary>
        /// KEY键前缀
        /// </summary>
        private string _keySuffix;

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheProvider" /> class.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        public MemoryCacheProvider(string appName)
        {
            _context = new Lazy<RedisContext>(() =>
            {
                if (CacheContainer.IsRegistered<RedisContext>(CacheTargetType.Redis.ToString()))
                    return CacheContainer.GetService<RedisContext>(appName);
                return CacheContainer.GetInstances<RedisContext>(appName);
            });

            _keySuffix = appName;
            _defaultExpireTime = new Lazy<long>(() => long.Parse(_context.Value._defaultExpireTime));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheProvider" /> class.
        /// </summary>
        public MemoryCacheProvider()
        {
            _defaultExpireTime = new Lazy<long>(() => 60);
            _keySuffix = string.Empty;
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, object value)
        {
            MemoryCache.Set(GetKeySuffix(key), value, _defaultExpireTime.Value);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public async void AddAsync(string key, object value)
        {
            await Task.Run(() => MemoryCache.Set(GetKeySuffix(key), value, DefaultExpireTime));
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="defaultExpire">if set to <c>true</c> [default expire].</param>
        public void Add(string key, object value, bool defaultExpire)
        {
            MemoryCache.Set(GetKeySuffix(key), value, defaultExpire ? DefaultExpireTime : ExpireTime);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="defaultExpire">if set to <c>true</c> [default expire].</param>
        public async void AddAsync(string key, object value, bool defaultExpire)
        {
            await Task.Run(() =>
                MemoryCache.Set(GetKeySuffix(key), value, defaultExpire ? DefaultExpireTime : ExpireTime));
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="numOfMinutes">The number of minutes.</param>
        public void Add(string key, object value, long numOfMinutes)
        {
            MemoryCache.Set(GetKeySuffix(key), value, numOfMinutes * 60);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="numOfMinutes">The number of minutes.</param>
        public async void AddAsync(string key, object value, long numOfMinutes)
        {
            await Task.Run(() => MemoryCache.Set(GetKeySuffix(key), value, numOfMinutes * 60));
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        public void Add(string key, object value, TimeSpan timeSpan)
        {
            MemoryCache.Set(GetKeySuffix(key), value, timeSpan.TotalSeconds);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        public async void AddAsync(string key, object value, TimeSpan timeSpan)
        {
            await Task.Run(() => MemoryCache.Set(GetKeySuffix(key), value, timeSpan.TotalSeconds));
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns>IDictionary&lt;System.String, T&gt;.</returns>
        public IDictionary<string, T> Get<T>(IEnumerable<string> keys)
        {
            keys.ToList().ForEach(key => key = GetKeySuffix(key));
            return MemoryCache.Get<T>(keys);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns>Task&lt;IDictionary&lt;System.String, T&gt;&gt;.</returns>
        public async Task<IDictionary<string, T>> GetAsync<T>(IEnumerable<string> keys)
        {
            keys.ToList().ForEach(key => key = GetKeySuffix(key));
            var result = await Task.Run(() => MemoryCache.Get<T>(keys));
            return result;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public object Get(string key)
        {
            return MemoryCache.Get(GetKeySuffix(key));
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        public async Task<object> GetAsync(string key)
        {
            var result = await Task.Run(() => MemoryCache.Get(GetKeySuffix(key)));
            return result;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public T Get<T>(string key)
        {
            return MemoryCache.Get<T>(GetKeySuffix(key));
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetAsync<T>(string key)
        {
            var result = await Task.Run(() => MemoryCache.Get<T>(GetKeySuffix(key)));
            return result;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool GetCacheTryParse(string key, out object obj)
        {
            return MemoryCache.GetCacheTryParse(GetKeySuffix(key), out obj);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            MemoryCache.RemoveByPattern(GetKeySuffix(key));
        }

        /// <summary>
        /// remove as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        public async void RemoveAsync(string key)
        {
            await Task.Run(() => MemoryCache.Remove(GetKeySuffix(key)));
        }

        /// <summary>
        /// 连接缓存终结点
        /// </summary>
        /// <param name="endpoint">终结点</param>
        /// <returns>是否连接成功</returns>
        public Task<bool> ConnectionAsync(CacheEndpoint endpoint)
        {
            return Task.FromResult(true);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 默认缓存失效时间
        /// </summary>
        public long DefaultExpireTime
        {
            get => _defaultExpireTime.Value;
            set { _defaultExpireTime = new Lazy<long>(() => value); }
        }

        /// <summary>
        /// KEY前缀
        /// </summary>
        public string KeySuffix
        {
            get => _keySuffix;
            set => _keySuffix = value;
        }

        #endregion
    }
}