using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace KissU.ServiceHosting
{
    /// <summary>
    /// 服务主机
    /// </summary>
    public interface IServiceHostBuilder : IHostBuilder
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="configureDelegate">注册服务的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">container</exception>
        IServiceHostBuilder ConfigureContainer(Action<ContainerBuilder> configureDelegate);

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="configureDelegate">配置容器的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">container</exception>
        IServiceHostBuilder Configure(Action<IContainer> configureDelegate);

        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="action">配置构建器的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">action</exception>
        IServiceHostBuilder ConfigureConfiguration(Action<IConfigurationBuilder> action);
    }
}