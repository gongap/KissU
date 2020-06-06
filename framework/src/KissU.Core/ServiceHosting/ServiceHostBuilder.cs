using System;
using System.Collections.Generic;
using Autofac;
using KissU.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KissU.ServiceHosting
{
    /// <summary>
    /// 服务主机
    /// </summary>
    public class ServiceHostBuilder : IServiceHostBuilder
    {
        private readonly IHostBuilder _hostBuilder;
        private readonly List<Action<ContainerBuilder>> _configureContainerDelegates;
        private readonly List<Action<IContainer>> _configureDelegates;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostBuilder" /> class.
        /// 初始化
        /// </summary>
        public ServiceHostBuilder(IHostBuilder hostBuilder)
        {
            _hostBuilder = hostBuilder ?? throw new ArgumentNullException(nameof(hostBuilder));
            _configureContainerDelegates = new List<Action<ContainerBuilder>>();
            _configureDelegates = new List<Action<IContainer>>();
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="configureDelegate">注册服务的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">container</exception>
        public IHostBuilder ConfigureContainer(Action<ContainerBuilder> configureDelegate)
        {
            if (configureDelegate == null)
            {
                throw new ArgumentNullException(nameof(configureDelegate));
            }

            _configureContainerDelegates.Add(configureDelegate);
            return this;
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="configureDelegate">配置容器的委托</param>
        /// <returns>服务主机构建器</returns>
        /// <exception cref="ArgumentNullException">container</exception>
        public IHostBuilder Configure(Action<IContainer> configureDelegate)
        {
            if (configureDelegate == null)
            {
                throw new ArgumentNullException(nameof(configureDelegate));
            }

            _configureDelegates.Add(configureDelegate);
            return this;
        }

        /// <summary>
        /// 构建主机
        /// </summary>
        /// <returns>An initialized <see cref="T:Microsoft.Extensions.Hosting.IHost" />.</returns>
        public IHost Build()
        {
            _hostBuilder.ConfigureHostConfiguration(configurationBuilder =>
            {
                _hostBuilder.ConfigureServices(services =>
                {
                    services.AddSingleton(typeof(IConfigurationBuilder), configurationBuilder);
                });
            });

            _hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory(
                builder =>
                {
                    foreach (var configure in _configureContainerDelegates)
                    {
                        configure(builder);
                    }
                }, container =>
                {
                    foreach (var configure in _configureDelegates)
                    {
                        configure(container);
                    }
                })
            );

            return _hostBuilder.Build();
        }

        /// <summary>
        /// A central location for sharing state between components during the host building process.
        /// </summary>
        public IDictionary<object, object> Properties => _hostBuilder.Properties;

        /// <summary>
        /// Set up the configuration for the builder itself. This will be used to initialize the <see cref="T:Microsoft.Extensions.Hosting.IHostEnvironment" />
        /// for use later in the build process. This can be called multiple times and the results will be additive.
        /// </summary>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" /> that will be used
        /// to construct the <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> for the host.</param>
        /// <returns>The same instance of the <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> for chaining.</returns>
        public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate)
        {
            _hostBuilder.ConfigureHostConfiguration(configureDelegate);
            return this;
        }

        /// <summary>
        /// Sets up the configuration for the remainder of the build process and application. This can be called multiple times and
        /// the results will be additive. The results will be available at <see cref="P:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration" /> for
        /// subsequent operations, as well as in <see cref="P:Microsoft.Extensions.Hosting.IHost.Services" />.
        /// </summary>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" /> that will be used
        /// to construct the <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> for the application.</param>
        /// <returns>The same instance of the <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> for chaining.</returns>
        public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            _hostBuilder.ConfigureAppConfiguration(configureDelegate);
            return this;
        }

        /// <summary>
        /// Adds services to the container. This can be called multiple times and the results will be additive.
        /// </summary>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> that will be used
        /// to construct the <see cref="T:System.IServiceProvider" />.</param>
        /// <returns>The same instance of the <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> for chaining.</returns>
        public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            _hostBuilder.ConfigureServices(configureDelegate);
            return this;
        }

        /// <summary>
        /// Overrides the factory used to create the service provider.
        /// </summary>
        /// <typeparam name="TContainerBuilder">The type of builder.</typeparam>
        /// <param name="factory">The factory to register.</param>
        /// <returns>The same instance of the <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> for chaining.</returns>
        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory)
        {
            _hostBuilder.UseServiceProviderFactory(factory);
            return this;
        }

        /// <summary>
        /// Overrides the factory used to create the service provider.
        /// </summary>
        /// <typeparam name="TContainerBuilder">The type of builder.</typeparam>
        /// <returns>The same instance of the <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> for chaining.</returns>
        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory)
        {
            _hostBuilder.UseServiceProviderFactory(factory);
            return this;
        }

        /// <summary>
        /// Enables configuring the instantiated dependency container. This can be called multiple times and
        /// the results will be additive.
        /// </summary>
        /// <typeparam name="TContainerBuilder">The type of builder.</typeparam>
        /// <param name="configureDelegate">The delegate which configures the builder.</param>
        /// <returns>The same instance of the <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> for chaining.</returns>
        public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate)
        {
            _hostBuilder.ConfigureContainer(configureDelegate);
            return this;
        }
    }
}