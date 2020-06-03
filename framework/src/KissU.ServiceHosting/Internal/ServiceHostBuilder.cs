using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KissU.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.ServiceHosting.Internal
{
    /// <summary>
    /// 服务主机构建器
    /// </summary>
    public class ServiceHostBuilder : IServiceHostBuilder
    {
        private readonly List<Action<IConfigurationBuilder>> _configureHostConfigurationDelegates;
        private readonly List<Action<IServiceCollection>> _configureServicesDelegates;
        private readonly List<Action<ContainerBuilder>> _configureContainerDelegates;
        private readonly List<Action<IContainer>> _configureDelegates;
        private Action<ILoggingBuilder> _loggingDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostBuilder" /> class.
        /// 初始化
        /// </summary>
        public ServiceHostBuilder()
        {
            _configureHostConfigurationDelegates = new List<Action<IConfigurationBuilder>>();
            _configureServicesDelegates = new List<Action<IServiceCollection>>();
            _configureContainerDelegates = new List<Action<ContainerBuilder>>();
            _configureDelegates = new List<Action<IContainer>>();
        }

        /// <summary>
        /// 构建服务主机
        /// </summary>
        /// <returns>服务主机</returns>
        public IServiceHost Build()
        {
            var services = ConfigureServices();
            var config = ConfigureHostConfiguration();
            if (_loggingDelegate != null)
            {
                services.AddLogging(_loggingDelegate);
            }
            else
            {
                services.AddLogging();
            }

            services.AddSingleton(typeof(IConfigurationBuilder), config);
            var containerBuilder = ConfigureContainer();
            var serviceProvider = services.BuildServiceProvider();
            containerBuilder.Populate(services);
            var hostLifetime = serviceProvider.GetService<IHostLifetime>();
            var host = new ServiceHost(containerBuilder, serviceProvider, hostLifetime, _configureDelegates);
            ServiceLocator.Current = host.Initialize();
            return host;
        }

        /// <summary>
        /// 配置服务集合
        /// </summary>
        /// <param name="action">用于服务集合的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">action</exception>
        public IServiceHostBuilder ConfigureServices(Action<IServiceCollection> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _configureServicesDelegates.Add(action);
            return this;
        }

        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="action">配置构建器的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">action</exception>
        public IServiceHostBuilder Configure(Action<IConfigurationBuilder> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _configureHostConfigurationDelegates.Add(action);
            return this;
        }

        /// <summary>
        /// 配置日志记录提供程序
        /// </summary>
        /// <param name="action">用于配置日志记录提供程序的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">action</exception>
        public IServiceHostBuilder ConfigureLogging(Action<ILoggingBuilder> action)
        {
            _loggingDelegate = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="action">配置服务的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">action</exception>
        public IServiceHostBuilder ConfigureContainer(Action<ContainerBuilder> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _configureContainerDelegates.Add(action);
            return this;
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="action">配置容器的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">container</exception>
        public IServiceHostBuilder Configure(Action<IContainer> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _configureDelegates.Add(action);
            return this;
        }

        private IConfigurationBuilder ConfigureHostConfiguration()
        {
            var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory);
            foreach (var configure in _configureHostConfigurationDelegates)
            {
                configure(config);
            }

            return config;
        }

        private IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            foreach (var configureServices in _configureServicesDelegates)
            {
                configureServices(services);
            }

            return services;
        }

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