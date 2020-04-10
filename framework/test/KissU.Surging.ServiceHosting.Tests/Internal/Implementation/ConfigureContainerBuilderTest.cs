using System;
using Autofac;
using KissU.Surging.ServiceHosting.Internal.Implementation;
using KissU.Surging.ServiceHosting.Tests.Samples;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Internal.Implementation
{
    /// <summary>
    /// 容器配置构建器测试.
    /// </summary>
    public class ConfigureContainerBuilderTest
    {
        /// <summary>
        /// 测试构造函数.
        /// </summary>
        [Fact()]
        public void TestConfigureContainerBuilder()
        {
            var methodInfo = typeof(StartupSample).GetMethod("ConfigureContainer");
            var builder = new ConfigureContainerBuilder(methodInfo);
            Assert.True(builder.MethodInfo == methodInfo);
        }

        /// <summary>
        /// 测试构建.
        /// </summary>
        [Fact()]
        public void TestBuild()
        {
            var sample = new StartupSample();
            var methodInfo = sample.GetType().GetMethod("ConfigureContainer");
            var builder = new ConfigureContainerBuilder(methodInfo);
            var action = builder.Build(sample);
        }

        /// <summary>
        /// 测试获取容器类型
        /// </summary>
        [Fact()]
        public void TestGetContainerType()
        {
            var sample = new StartupSample();
            var methodInfo = sample.GetType().GetMethod("ConfigureContainer");
            var builder = new ConfigureContainerBuilder(methodInfo);
            var containerType = builder.GetContainerType();
            Assert.True(containerType == typeof(IContainer));
        }

        /// <summary>
        /// 测试获取容器类型-UpdateInfo方法必须有一个参数
        /// </summary>
        [Fact()]
        public void TestGetContainerType_ThrowInvalidOperationException()
        {
            var sample = new StartupSample();
            var methodInfo = sample.GetType().GetMethod("Configure");
            var builder = new ConfigureContainerBuilder(methodInfo);
            Assert.Throws(typeof(InvalidOperationException), () => { builder.GetContainerType(); });
        }
    }
}