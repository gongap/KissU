using Autofac;
using KissU.Core.ServiceHosting.Startup.Implementation;
using KissU.Core.ServiceHosting.Tests.Samples;
using NSubstitute;
using Xunit;

namespace KissU.Core.ServiceHosting.Tests.Startup.Implementation
{
    /// <summary>
    /// 基于约定的启动测试.
    /// </summary>
    public class ConventionBasedStartupTest
    {
        /// <summary>
        /// 测试配置应用
        /// </summary>
        [Fact]
        public void TestConfigure()
        {
            var tag = false;
            var instance = new StartupBaseSample();

            void Configure(IContainer c)
            {
                tag = true;
            }

            IContainer ConfigureServices(ContainerBuilder builder)
            {
                return Substitute.For<IContainer>();
            }

            var startupMethods = new StartupMethods(instance, Configure, ConfigureServices);
            var startup = new ConventionBasedStartup(startupMethods);
            var container = Substitute.For<IContainer>();
            startup.Configure(container);
            Assert.True(tag);
        }

        /// <summary>
        /// 测试配置服务
        /// </summary>
        [Fact]
        public void TestConfigureServices()
        {
            var instance = new StartupBaseSample();
            var container1 = Substitute.For<IContainer>();

            void Configure(IContainer c)
            {
            }

            IContainer ConfigureServices(ContainerBuilder b)
            {
                return container1;
            }

            var startupMethods = new StartupMethods(instance, Configure, ConfigureServices);
            var startup = new ConventionBasedStartup(startupMethods);
            var builder = new ContainerBuilder();
            var container2 = startup.ConfigureServices(builder);
            Assert.True(container1 == container2);
        }
    }
}