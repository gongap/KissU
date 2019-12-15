using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Core.ServiceHosting.Internal
{
    /// <summary>
    /// 服务主机构建器
    /// </summary>
    public interface IServiceHostBuilder
    {
        /// <summary>
        /// 构建服务主机
        /// </summary>
        /// <returns></returns>
        IServiceHost Build();

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder RegisterServices(Action<ContainerBuilder> builder);

        /// <summary>
        /// 配置日志记录提供程序
        /// </summary>
        /// <param name="configure">用于配置日志记录提供程序的委托 </param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder ConfigureLogging(Action<ILoggingBuilder> configure);

        /// <summary>
        /// 配置服务集合
        /// </summary>
        /// <param name="configureServices">用于服务集合的委托 </param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);

        /// <summary>
        /// 配置应用程序
        /// </summary>
        /// <param name="builder">配置构建器</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder Configure(Action<IConfigurationBuilder> builder);

        /// <summary>
        /// 映射服务
        /// </summary>
        /// <param name="mapper">映射器</param>
        /// <returns>服务主机构建器</returns>
        IServiceHostBuilder MapServices(Action<IContainer> mapper);
    }
}
