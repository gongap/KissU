﻿using Autofac;
using KissU.Core.Caching.Configurations;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.EventBusKafka.Configurations;
using KissU.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Services.SampleB.Host
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// 初始化启动配置
        /// </summary>
        public Startup(IConfigurationBuilder build)
        {
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IContainer ConfigureServices(ContainerBuilder builder)
        {
            var serivces = new ServiceCollection();
            ServiceLocator.Current = builder.AddUtil(serivces);
            return ServiceLocator.Current;
        }

        /// <summary>
        /// 配置应用
        /// </summary>
        public void Configure(IContainer app)
        {
        }
    }
}