using Autofac;
using KissU.Surging.ServiceHosting.Startup;
using NSubstitute;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Startup.Implementation
{
    /// <summary>
    /// 委托启动测试.
    /// </summary>
    public class DelegateStartupTest
    {
        /// <summary>
        /// 测试配置应用
        /// </summary>
        [Fact]
        public void TestConfigure()
        {
            var tag = false;
            var container = Substitute.For<IContainer>();
            var startup = new DelegateStartup(c => { tag = true; });
            startup.Configure(container);
            Assert.True(tag);
        }
    }
}