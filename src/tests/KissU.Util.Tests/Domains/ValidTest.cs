using System;
using Autofac;
using KissU.Core.Dependency;
using KissU.Core.Exceptions;
using KissU.Core.Helpers;
using KissU.Util.Tests.Samples;
using KissU.Util.Tests.XUnitHelpers;
using Xunit;
using IContainer = KissU.Core.Dependency.IContainer;

namespace KissU.Util.Tests.Domains
{
    /// <summary>
    /// 验证测试
    /// </summary>
    public class ValidTest : IDisposable
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public ValidTest()
        {
            _container = Ioc.CreateContainer(new IocConfig());
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }

        /// <summary>
        /// 容器
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        /// 测试添加时验证无效
        /// </summary>
        [Fact]
        public void TestAdd_Invalid()
        {
            var entity = new EntitySample();
            var repository = _container.Create<IRepositorySample>();
            AssertHelper.Throws<Warning>(() => repository.Add(entity), "名称不能为空");
        }

        /// <summary>
        /// 测试添加时验证有效
        /// </summary>
        [Fact]
        public void TestAdd_Valid()
        {
            var entity = new EntitySample {Name = "a"};
            var repository = _container.Create<IRepositorySample>();
            repository.Add(entity);
        }
    }

    /// <summary>
    /// Ioc配置
    /// </summary>
    public class IocConfig : ConfigBase
    {
        /// <summary>
        /// Loads the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddScoped<IRepositorySample, RepositorySample>();
        }
    }
}