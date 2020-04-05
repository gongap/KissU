﻿using EasyCaching.InMemory;
using KissU.Core.Caches;
using KissU.Core.Helpers;
using KissU.Util.Caches.EasyCaching;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace KissU.Util.Tests.Caches
{
    /// <summary>
    /// EasyCaching缓存测试
    /// </summary>
    public class EasyCachingCacheTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public EasyCachingCacheTest()
        {
            var services = new ServiceCollection();
            services.AddCache(options => options.UseInMemory());
            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetService<ICache>();
        }

        /// <summary>
        /// EasyCaching缓存
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// 测试并发获取缓存时，应该只有一个操作会访问数据源
        /// </summary>
        [Fact(Skip = "偶尔运行失败")]
        public void Test_1()
        {
            var i = 0;
            Thread.ParallelExecute(() => { _cache.Get("EasyCachingCacheTest_1", () => i++); }, 20);
            Assert.Equal(1, i);
        }
    }
}