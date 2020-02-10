using Autofac;
using KissU.Core.ServiceHosting.Tests.Samples;
using Xunit;

namespace KissU.Core.ServiceHosting.Tests.Startup.Implementation
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
            var startup = new StartupSample();
            var container = startup.CreateServiceProvider(builder);
            Assert.NotNull(container);
        }
    }
}