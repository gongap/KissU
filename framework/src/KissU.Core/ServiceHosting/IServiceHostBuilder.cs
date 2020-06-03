using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.ServiceHosting
{
    /// <summary>
    /// 服务主机构建器
    /// </summary>
    public interface IServiceHostBuilder
    {
        /// <summary>
        /// 构建服务主机
        /// </summary>
        /// <returns>服务主机</returns>
        IServiceHost Build();

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder ConfigureContainer(Action<ContainerBuilder> builder);

        /// <summary>
        /// 配置日志记录提供程序
        /// </summary>
        /// <param name="logging">日志记录提供程序</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder ConfigureLogging(Action<ILoggingBuilder> logging);

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="serviceAction">服务集合</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder ConfigureServices(Action<IServiceCollection> serviceAction);

        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="config">配置</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder Configure(Action<IConfigurationBuilder> config);

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="container">容器</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder Configure(Action<IContainer> container);
    }
}