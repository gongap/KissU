using KissU.Surging.ServiceHosting.Internal;
using KissU.Surging.ServiceHosting.Tests.Samples;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Internal.Implementation
{
    /// <summary>
    /// ConfigureServicesBuilderTest.
    /// </summary>
    public class ConfigureServicesBuilderTest
    {
        /// <summary>
        /// 测试构造函数.
        /// </summary>
        [Fact()]
        public void TestConfigureServicesBuilder()
        {
            var methodInfo = typeof(StartupSample).GetMethod("ConfigureServices");
            var builder = new ConfigureServicesBuilder(methodInfo);
            Assert.True(builder.MethodInfo == methodInfo);
        }

        /// <summary>
        /// 测试构建.
        /// </summary>
        [Fact()]
        public void TestBuild()
        {
            var sample = new StartupSample();
            var methodInfo = sample.GetType().GetMethod("ConfigureServices");
            var builder = new ConfigureServicesBuilder(methodInfo);
            var action = builder.Build(sample);
        }
    }
}