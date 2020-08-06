using System;
using Autofac;
using KissU.Modularity;
using Microsoft.Extensions.DependencyInjection;

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
        /// <param name="services">服务集合</param>
        /// <exception cref="ArgumentNullException">builder</exception>
        public ServiceBuilder(ContainerBuilder builder, IServiceCollection services = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            ContainerBuilder = builder;
            Services = services ?? new ServiceCollection();
        }

        /// <summary>
        /// 容器构建器
        /// </summary>
        public ContainerBuilder ContainerBuilder { get; set; }

        /// <summary>
        /// 服务集合
        /// </summary>
        public IServiceCollection Services { get; set; }
    }
}