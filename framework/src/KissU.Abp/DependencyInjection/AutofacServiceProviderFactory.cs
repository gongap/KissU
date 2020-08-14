using System;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using KissU.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Abp.DependencyInjection
{
    /// <summary>
    /// A factory for creating a <see cref="ContainerBuilder"/> and an <see cref="IServiceProvider" />.
    /// </summary>
    public class AutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        private readonly ContainerBuilder _builder;
        private IServiceCollection _services;
        private readonly Action<ContainerBuilder> _configurationAction;
        private readonly Action<IContainer> _configureDelegates;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory"/> class.
        /// </summary>
        /// <param name="configurationAction">Action on a <see cref="ContainerBuilder"/> that adds component registrations to the conatiner.</param>
        /// <param name="configureDelegates">Action on a <see cref="Container"/> that adds component registrations to the conatiner.</param>
        public AutofacServiceProviderFactory(Action<ContainerBuilder> configurationAction = null, Action<IContainer> configureDelegates = null)
            : this(new ContainerBuilder(), configurationAction, configureDelegates)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory"/> class.
        /// </summary>
        /// <param name="configurationAction">Action on a <see cref="ContainerBuilder"/> that adds component registrations to the conatiner.</param>
        /// <param name="configureDelegates">Action on a <see cref="Container"/> that adds component registrations to the conatiner.</param>
        public AutofacServiceProviderFactory(ContainerBuilder builder, Action<ContainerBuilder> configurationAction = null, Action<IContainer> configureDelegates = null)
        {
            _builder = builder;
            _configurationAction = configurationAction ?? (configure => { });
            _configureDelegates = configureDelegates ?? (configure => { });
        }

        /// <summary>
        /// Creates a container builder from an <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        /// <returns>A container builder that can be used to create an <see cref="IServiceProvider" />.</returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            _services = services;

            _builder.Populate(services);

            _configurationAction(_builder);

            return _builder;
        }

        /// <summary>
        /// Creates an <see cref="IServiceProvider" /> from the container builder.
        /// </summary>
        /// <param name="containerBuilder">The container builder.</param>
        /// <returns>An <see cref="IServiceProvider" />.</returns>
        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            if (containerBuilder == null) throw new ArgumentNullException(nameof(containerBuilder));

            var container = containerBuilder.Build();

            ServiceLocator.Register(container);

            _configureDelegates(container);

            return new AutofacServiceProvider(container);
        }
    }
}
