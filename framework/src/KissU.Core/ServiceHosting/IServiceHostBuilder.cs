using System;
using Autofac;
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
        IHostBuilder ConfigureContainer(Action<ContainerBuilder> configureDelegate);

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="configureDelegate">配置容器的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">container</exception>
        IHostBuilder Configure(Action<IContainer> configureDelegate);
    }
}