using System.Reflection;
using KissU.Core.ServiceHosting.Internal.Implementation;
using KissU.Core.ServiceHosting.Tests.Samples;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace KissU.Core.ServiceHosting.Tests.Internal.Implementation
{
    /// <summary>
    /// 配置构建器测试.
    /// </summary>
    public class ConfigureBuilderTest
    {
        /// <summary>
        /// 测试构造函数.
        /// </summary>
        [Fact()]
        public void TestConfigureBuilder()
        {
            var methodInfo = typeof(StartupSample).GetMethod("Configure");
            var builder = new ConfigureBuilder(methodInfo);
            Assert.True(builder.MethodInfo == methodInfo);
        }

        /// <summary>
        /// 测试构建.
        /// </summary>
        [Fact()]
        public void TestBuild()
        {
            var sample = new StartupSample();
            var methodInfo = sample.GetType().GetMethod("Configure");
            var builder = new ConfigureBuilder(methodInfo);
            var action = builder.Build(sample);
        }
    }
}