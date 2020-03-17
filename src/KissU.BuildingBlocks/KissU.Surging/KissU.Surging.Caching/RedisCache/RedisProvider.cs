using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Surging.Caching.AddressResolvers;
using KissU.Surging.Caching.HashAlgorithms;
using KissU.Surging.Caching.Interfaces;
using KissU.Surging.CPlatform.Cache;
using StackExchange.Redis;

namespace KissU.Surging.Caching.RedisCache
{
    /// <summary>
    /// RedisProvider.
    /// Implements the <see cref="KissU.Surging.CPlatform.Cache.ICacheProvider" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Cache.ICacheProvider" />
    [IdentifyCache(CacheTargetType.Redis)]
    public class RedisProvider : ICacheProvider
    {
        #region 字段

        private readonly Lazy<RedisContext> _context;
        private Lazy<long> _defaultExpireTime;
        private const double ExpireTime = 60D;
        private Lazy<int> _connectTimeout;
        private readonly Lazy<ICacheClient<IDatabase>> _cacheClient;
        private readonly IAddressResolver addressResolver;

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisProvider" /> class.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        public RedisProvider(string appName)
        {
            _context = new Lazy<RedisContext>(() =>
            {
                if (CacheContainer.IsRegistered<RedisContext>(appName))
                    return CacheContainer.GetService<RedisContext>(appName);
                return CacheContainer.GetInstances<RedisContext>(appName);
            });
            KeySuffix = appName;
            _defaultExpireTime = new Lazy<long>(() => long.Parse(_context.Value._defaultExpireTime));
            _connectTimeout = new Lazy<int>(() => int.Parse(_context.Value._connectTimeout));
            if (CacheContainer.IsRegistered<ICacheClient<IDatabase>>(CacheTargetType.Redis.ToString()))
            {
                addressResolver = CacheContainer.GetService<IAddressResolver>();
                _cacheClient = new Lazy<ICacheClient<IDatabase>>(() =>
                    CacheContainer.GetService<ICacheClient<IDatabase>>(CacheTargetType.Redis.ToString()));
            }
            else
                _cacheClient = new Lazy<ICacheClient<IDatabase>>(() =>
                    CacheContainer.GetInstances<ICacheClient<IDatabase>>(CacheTargetType.Redis.ToString()));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisProvider" /> class.
        /// </summary>
        public RedisProvider()
        {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 添加K/V值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void Add(string key, object value)
        {
            Add(key, value, TimeSpan.FromSeconds(ExpireTime));
        }

        /// <summary>
        /// 异步添加K/V值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void AddAsync(string key, object value)
        {
            AddTaskAsync(key, value, TimeSpan.FromSeconds(ExpireTime));
        }

        /// <summary>
        /// 添加k/v值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="defaultExpire">默认配置失效时间</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void Add(string key, object value, bool defaultExpire)
        {
            Add(key, value, TimeSpan.FromSeconds(defaultExpire ? DefaultExpireTime : ExpireTime));
        }

        /// <summary>
        /// 异步添加K/V值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="defaultExpire">默认配置失效时间</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void AddAsync(string key, object value, bool defaultExpire)
        {
            AddTaskAsync(key, value, TimeSpan.FromSeconds(defaultExpire ? DefaultExpireTime : ExpireTime));
        }

        /// <summary>
        /// 添加k/v值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="numOfMinutes">默认配置失效时间</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void Add(string key, object value, long numOfMinutes)
        {
            Add(key, value, TimeSpan.FromMinutes(numOfMinutes));
        }


        /// <summary>
        /// 异步添加K/V值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="numOfMinutes">默认配置失效时间</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void AddAsync(string key, object value, long numOfMinutes)
        {
            AddTaskAsync(key, value, TimeSpan.FromMinutes(numOfMinutes));
        }


        /// <summary>
        /// 添加k/v值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="timeSpan">配置时间间隔</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void Add(string key, object value, TimeSpan timeSpan)
        {
            var node = GetRedisNode(key);
            var redis = GetRedisClient(new RedisEndpoint
            {
                DbIndex = int.Parse(node.Db),
                Host = node.Host,
                Password = node.Password,
                Port = int.Parse(node.Port),
                MinSize = int.Parse(node.MinSize),
                MaxSize = int.Parse(node.MaxSize)
            });
            redis.Set(GetKeySuffix(key), value, timeSpan);
        }

        /// <summary>
        /// 异步添加K/V值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="timeSpan">配置时间间隔</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void AddAsync(string key, object value, TimeSpan timeSpan)
        {
            AddTaskAsync(key, value, timeSpan);
        }

        /// <summary>
        /// 根据KEY键集合获取返回对象集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="keys">KEY值集合</param>
        /// <returns>需要返回的对象集合</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public IDictionary<string, T> Get<T>(IEnumerable<string> keys)
        {
            IDictionary<string, T> result = null;
            foreach (var key in keys)
            {
                var node = GetRedisNode(key);
                var redis = GetRedisClient(new RedisEndpoint
                {
                    DbIndex = int.Parse(node.Db),
                    Host = node.Host,
                    Password = node.Password,
                    Port = int.Parse(node.Port),
                    MinSize = int.Parse(node.MinSize),
                    MaxSize = int.Parse(node.MaxSize)
                });
                result.Add(key, redis.Get<T>(key));
            }

            return result;
        }

        /// <summary>
        /// 根据KEY键集合异步获取返回对象集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="keys">KEY值集合</param>
        /// <returns>需要返回的对象集合</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public async Task<IDictionary<string, T>> GetAsync<T>(IEnumerable<string> keys)
        {
            IDictionary<string, T> result = null;
            foreach (var key in keys)
            {
                var node = GetRedisNode(key);
                var redis = GetRedisClient(new RedisEndpoint
                {
                    DbIndex = int.Parse(node.Db),
                    Host = node.Host,
                    Password = node.Password,
                    Port = int.Parse(node.Port),
                    MinSize = int.Parse(node.MinSize),
                    MaxSize = int.Parse(node.MaxSize)
                });
                result.Add(key, await redis.GetAsync<T>(key));
            }

            return result;
        }

        /// <summary>
        /// 根据KEY键获取返回对象
        /// </summary>
        /// <param name="key">KEY值</param>
        /// <returns>需要返回的对象</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public object Get(string key)
        {
            var o = Get<object>(key);
            return o;
        }

        /// <summary>
        /// 根据KEY异步获取返回对象
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        public async Task<object> GetAsync(string key)
        {
            var result = await GetTaskAsync<object>(key);
            return result;
        }

        /// <summary>
        /// 根据KEY键获取返回指定的类型对象
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">KEY值</param>
        /// <returns>需要返回的对象</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public T Get<T>(string key)
        {
            var node = GetRedisNode(key);
            var result = default(T);
            var redis = GetRedisClient(new RedisEndpoint
            {
                DbIndex = int.Parse(node.Db),
                Host = node.Host,
                Password = node.Password,
                Port = int.Parse(node.Port),
                MinSize = int.Parse(node.MinSize),
                MaxSize = int.Parse(node.MaxSize)
            });
            result = redis.Get<T>(GetKeySuffix(key));
            return result;
        }


        /// <summary>
        /// 根据KEY异步获取指定的类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetAsync<T>(string key)
        {
            var node = GetRedisNode(key);
            var redis = GetRedisClient(new RedisEndpoint
            {
                DbIndex = int.Parse(node.Db),
                Host = node.Host,
                Password = node.Password,
                Port = int.Parse(node.Port),
                MinSize = int.Parse(node.MinSize),
                MaxSize = int.Parse(node.MaxSize)
            });

            var result = await Task.Run(() => redis.Get<T>(GetKeySuffix(key)));
            return result;
        }

        /// <summary>
        /// 根据KEY键获取转化成指定的对象，指示获取转化是否成功的返回值
        /// </summary>
        /// <param name="key">KEY键</param>
        /// <param name="obj">需要转化返回的对象</param>
        /// <returns>是否成功</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public bool GetCacheTryParse(string key, out object obj)
        {
            obj = null;
            var o = Get<object>(key);
            obj = o;
            return o != null;
        }

        /// <summary>
        /// 根据KEY键删除缓存
        /// </summary>
        /// <param name="key">KEY键</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void Remove(string key)
        {
            var node = GetRedisNode(key);
            var redis = GetRedisClient(new RedisEndpoint
            {
                DbIndex = int.Parse(node.Db),
                Host = node.Host,
                Password = node.Password,
                Port = int.Parse(node.Port),
                MinSize = int.Parse(node.MinSize),
                MaxSize = int.Parse(node.MaxSize)
            });
            redis.Remove(GetKeySuffix(key));
        }

        /// <summary>
        /// 根据KEY键异步删除缓存
        /// </summary>
        /// <param name="key">KEY键</param>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public void RemoveAsync(string key)
        {
            RemoveTaskAsync(key);
        }

        /// <summary>
        /// 默认的过期时间.
        /// </summary>
        public long DefaultExpireTime
        {
            get => _defaultExpireTime.Value;
            set { _defaultExpireTime = new Lazy<long>(() => value); }
        }

        /// <summary>
        /// 键后缀。
        /// </summary>
        public string KeySuffix { get; set; }


        /// <summary>
        /// Gets or sets the connect timeout.
        /// </summary>
        public int ConnectTimeout
        {
            get => _connectTimeout.Value;
            set { _connectTimeout = new Lazy<int>(() => value); }
        }

        #endregion

        #region 私有方法

        private IDatabase GetRedisClient(CacheEndpoint info)
        {
            return
                _cacheClient.Value
                    .GetClient(info, ConnectTimeout);
        }

        private ConsistentHashNode GetRedisNode(string item)
        {
            if (addressResolver != null)
            {
                return addressResolver.Resolver($"{KeySuffix}.{CacheTargetType.Redis.ToString()}", item).Result;
            }

            ConsistentHash<ConsistentHashNode> hash;
            _context.Value.dicHash.TryGetValue(CacheTargetType.Redis.ToString(), out hash);
            return hash != null ? hash.GetItemNode(item) : default;
        }

        private async Task<T> GetTaskAsync<T>(string key)
        {
            return await Task.Run(() => Get<T>(key));
        }

        private async void AddTaskAsync(string key, object value, TimeSpan timeSpan)
        {
            await Task.Run(() => Add(key, value, timeSpan));
        }

        private async void RemoveTaskAsync(string key)
        {
            await Task.Run(() => Remove(key));
        }

        private string GetKeySuffix(string key)
        {
            return string.IsNullOrEmpty(KeySuffix) ? key : string.Format("_{0}_{1}", KeySuffix, key);
        }

        /// <summary>
        /// connection as an asynchronous operation.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> ConnectionAsync(CacheEndpoint endpoint)
        {
            var connection = await _cacheClient
                .Value.ConnectionAsync(endpoint, ConnectTimeout);
            return connection;
        }

        #endregion
    }
}