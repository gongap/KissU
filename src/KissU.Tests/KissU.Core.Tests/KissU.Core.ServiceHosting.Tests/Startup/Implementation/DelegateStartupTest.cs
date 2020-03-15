using Autofac;
using KissU.Core.ServiceHosting.Startup.Implementation;
using NSubstitute;
using Xunit;

namespace KissU.Core.ServiceHosting.Tests.Startup.Implementation
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