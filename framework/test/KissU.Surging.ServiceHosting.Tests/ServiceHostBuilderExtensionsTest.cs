using KissU.ServiceHosting;
using KissU.ServiceHosting.Extensions;
using KissU.ServiceHosting.Internal;
using KissU.Surging.ServiceHosting.Tests.Samples;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests
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
            builder.UseStartup(typeof(StartupBaseSample));
        }

        /// <summary>
        /// 测试使用启动类
        /// </summary>
        [Fact]
        public void TestUseStartup1()
        {
            var builder = new ServiceHostBuilder();
            builder.UseStartup<StartupBaseSample>();
        }
    }
}