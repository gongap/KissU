﻿using KissU.ServiceHosting.Extensions;
using KissU.Surging.ServiceHosting.Tests.Samples;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Extensions
{
    /// <summary>
    /// 服务集合扩展测试.
    /// </summary>
    public class ServiceCollectionExtensionsTest
    {
        /// <summary>
        /// 测试克隆
        /// </summary>
        [Fact]
        public void TestClone()
        {
            var services = new ServiceCollection();
            services.AddScoped<IStartupSample, StartupSample>();
            var clone = services.Clone();
            Assert.True(clone.Count == 1);
            Assert.True(clone[0].Equals(services[0]));
            Assert.False(clone == services);
        }
    }
}