﻿using System.Collections.Generic;
using Autofac;
using KissU.Util.Dependency;
using KissU.Util.Helpers;
using KissU.Util.Tests.Samples;
using Xunit;

namespace KissU.Util.Tests.Helpers {
    /// <summary>
    /// Ioc配置
    /// </summary>
    public class TestIocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            builder.AddScoped<ISample, Sample>();
        }
    }

    /// <summary>
    /// Ioc测试
    /// </summary>
    public class IocTest {
        /// <summary>
        /// 初始化Ioc测试
        /// </summary>
        public IocTest() {
            Ioc.Register( new TestIocConfig() );
        }

        /// <summary>
        /// 测试创建实例
        /// </summary>
        [Fact]
        public void TestCreate() {
            var sample = Ioc.Create<ISample>();
            Assert.NotNull( sample );
        }

        /// <summary>
        /// 测试创建实例
        /// </summary>
        [Fact]
        public void TestCreate_2() {
            var sample = Ioc.Create<ISample>(typeof(ISample));
            Assert.NotNull( sample );
        }

        /// <summary>
        /// 测试作用域
        /// </summary>
        [Fact]
        public void TestScope() {
            using ( var scope = Ioc.BeginScope() ) {
                var sample = scope.Create<ISample>();
                Assert.NotNull( sample );
            }
        }

        /// <summary>
        /// 测试集合
        /// </summary>
        [Fact]
        public void TestCollection() {
            var samples = Ioc.Create<IEnumerable<ISample>>();
            Assert.NotNull( samples );
            Assert.Single( samples );
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        [Fact]
        public void TestCreateList() {
            var samples = Ioc.CreateList<ISample>();
            Assert.NotNull( samples );
            Assert.Single( samples );
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        [Fact]
        public void TestCreateList_2() {
            var samples = Ioc.CreateList<ISample>( typeof( ISample ) );
            Assert.NotNull( samples );
            Assert.Single( samples );
        }
    }
}
