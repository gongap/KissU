using KissU.Core.ServiceHosting.Internal.Implementation;
using KissU.Core.ServiceHosting.Tests.Samples;
using Xunit;

namespace KissU.Core.ServiceHosting.Tests
{
    /// <summary>
    /// 服务主机生成器扩展测试
    /// </summary>
    public class ServiceHostBuilderExtensionsTest
    {
        /// <summary>
        /// 测试使用控制台生命周期
        /// </summary>
        [Fact]
        public void TestUseConsoleLifetime()
        {
            var builder = new ServiceHostBuilder();
            builder.UseConsoleLifetime();
        }

        /// <summary>
        /// 测试使用启动类
        /// </summary>
        [Fact]
        public void TestUseStartup()
        {
            var builder = new ServiceHostBuilder();
            builder.UseStartup(typeof(StartupSample));
        }

        /// <summary>
        /// 测试使用启动类
        /// </summary>
        [Fact]
        public void TestUseStartup1()
        {
            var builder = new ServiceHostBuilder();
            builder.UseStartup<StartupSample>();
        }
    }
}