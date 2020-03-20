using System;
using EasyCaching.InMemory;
using KissU.Core.Caches;
using KissU.Core.Locks.Default;
using KissU.Util.Caches;
using KissU.Util.Caches.EasyCaching;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util.Tests.Locks
{
    /// <summary>
    /// 业务锁测试服务
    /// </summary>
    public class LockTestService
    {
        /// <summary>
        /// 缓存
        /// </summary>
        private static readonly ICache Cache;

        /// <summary>
        /// 业务锁
        /// </summary>
        private readonly DefaultLock _lock;

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        static LockTestService()
        {
            var services = new ServiceCollection();
            services.AddCache(options => options.UseInMemory());
            var serviceProvider = services.BuildServiceProvider();
            Cache = serviceProvider.GetService<ICache>();
        }

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        public LockTestService()
        {
            _lock = new DefaultLock(Cache);
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expiration">The expiration.</param>
        /// <returns>System.String.</returns>
        public string Execute(string key, TimeSpan? expiration = null)
        {
            var result = _lock.Lock(key, expiration);
            return result ? "ok" : "fail";
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock()
        {
            _lock.UnLock();
        }
    }
}