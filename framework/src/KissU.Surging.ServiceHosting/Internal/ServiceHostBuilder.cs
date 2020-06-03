using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Core.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.ServiceHosting.Internal
{
    /// <summary>
    /// 服务主机构建器
    /// </summary>
    public class ServiceHostBuilder : IServiceHostBuilder
    {
        private readonly List<Action<IConfigurationBuilder>> _configureAppDelegates;
        private readonly List<Action<IServiceCollection>> _configureServicesDelegates;
        private readonly List<Action<IContainer>> _configureDelegates;
        private readonly List<Action<ContainerBuilder>> _configureContainerDelegates;
        private Action<ILoggingBuilder> _loggingDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostBuilder" /> class.
        /// 初始化
        /// </summary>
        public ServiceHostBuilder()
        {
            _configureServicesDelegates = new List<Action<IServiceCollection>>();
            _configureContainerDelegates = new List<Action<ContainerBuilder>>();
            _configureAppDelegates = new List<Action<IConfigurationBuilder>>();
            _configureDelegates = new List<Action<IContainer>>();
        }

        /// <summary>
        /// 构建服务主机
        /// </summary>
        /// <returns>服务主机</returns>
        public IServiceHost Build()
        {
            var services = BuildCommonServices();
            var config = Configure();
            if (_loggingDelegate != null)
            {
                services.AddLogging(_loggingDelegate);
            }
            else
            {
                services.AddLogging();
            }

            services.AddSingleton(typeof(IConfigurationBuilder), config);
            var hostingServices = ConfigureContainer();
            var applicationServices = services.Clone();
            var hostingServiceProvider = services.BuildServiceProvider();
            hostingServices.Populate(services);
            var hostLifetime = hostingServiceProvider.GetService<IHostLifetime>();
            var host = new ServiceHost(hostingServices, hostingServiceProvider, hostLifetime, _configureDelegates);
            var container = host.Initialize();
            return host;
        }

        /// <summary>
        /// 映射服务
        /// </summary>
        /// <param name="mapper">映射器</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">mapper</exception>
        public IServiceHostBuilder Configure(Action<IContainer> mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _configureDelegates.Add(mapper);
            return this;
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">builder</exception>
        public IServiceHostBuilder ConfigureContainer(Action<ContainerBuilder> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            _configureContainerDelegates.Add(builder);
            return this;
        }

        /// <summary>
        /// 配置服务集合
        /// </summary>
        /// <param name="configureServices">用于服务集合的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">configureServices</exception>
        public IServiceHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            if (configureServices == null)
            {
                throw new ArgumentNullException(nameof(configureServices));
            }

            _configureServicesDelegates.Add(configureServices);
            return this;
        }

        /// <summary>
        /// 配置应用程序
        /// </summary>
        /// <param name="builder">配置构建器</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">builder</exception>
        public IServiceHostBuilder Configure(Action<IConfigurationBuilder> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            _configureAppDelegates.Add(builder);
            return this;
        }

        /// <summary>
        /// 配置日志记录提供程序
        /// </summary>
        /// <param name="configure">用于配置日志记录提供程序的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">configure</exception>
        public IServiceHostBuilder ConfigureLogging(Action<ILoggingBuilder> configure)
        {
            _loggingDelegate = configure ?? throw new ArgumentNullException(nameof(configure));
            return this;
        }

        /// <summary>
        /// Builds the common services.
        /// </summary>
        /// <returns>IServiceCollection.</returns>
        private IServiceCollection BuildCommonServices()
        {
            var services = new ServiceCollection();
            foreach (var configureServices in _configureServicesDelegates)
            {
                configureServices(services);
            }

            return services;
        }

        /// <summary>
        /// Configures this instance.
        /// </summary>
        /// <returns>IConfigurationBuilder.</returns>
        private IConfigurationBuilder Configure()
        {
            var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory);
            foreach (var configure in _configureAppDelegates)
            {
                configure(config);
            }

            return config;
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <returns>容器构建器</returns>
        private ContainerBuilder ConfigureContainer()
        {
            var hostingServices = new ContainerBuilder();
            foreach (var registerServices in _configureContainerDelegates)
            {
                registerServices(hostingServices);
            }

            return hostingServices;
        }
    }
}