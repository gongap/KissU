﻿using System;
using Autofac;
using KissU.Modularity;

namespace KissU.CPlatform
{
    /// <summary>
    /// 默认服务构建器
    /// </summary>
    internal sealed class ServiceBuilder : IServiceBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBuilder" /> class.
        /// </summary>
        /// <param name="builder">容器构建器.</param>
        /// <exception cref="ArgumentNullException">builder</exception>
        public ServiceBuilder(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            ContainerBuilder = builder;
        }

        /// <summary>
        /// 容器构建器
        /// </summary>
        public ContainerBuilder ContainerBuilder { get; set; }
    }
}