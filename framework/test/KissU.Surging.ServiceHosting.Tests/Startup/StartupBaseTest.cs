using Autofac;
using KissU.Surging.ServiceHosting.Tests.Samples;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Startup
{
    /// <summary>
    /// 启动基类测试.
    /// </summary>
    public class StartupBaseTest
    {
        /// <summary>
        /// 测试创建服务提供程序
        /// </summary>
        [Fact]
        public void TestCreateServiceProvider()
        {
            var builder = new ContainerBuilder();
            var startup = new StartupBaseSample();
            var container = startup.BuildServiceProvider(builder);
            Assert.NotNull(container);
        }
    }
}