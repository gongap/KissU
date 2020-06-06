using System;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Dependency
{
    /// <summary>
    /// A factory for creating a <see cref="ContainerBuilder"/> and an <see cref="IServiceProvider" />.
    /// </summary>
    public class AutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        private readonly Action<ContainerBuilder> _configurationAction;
        private readonly Action<IContainer> _configureDelegates;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory"/> class.
        /// </summary>
        /// <param name="configurationAction">Action on a <see cref="ContainerBuilder"/> that adds component registrations to the conatiner.</param>
        /// <param name="configureDelegates">Action on a <see cref="Container"/> that adds component registrations to the conatiner.</param>
        public AutofacServiceProviderFactory(Action<ContainerBuilder> configurationAction = null, Action<IContainer> configureDelegates = null)
        {
            _configurationAction = configurationAction ?? (builder => { });
            _configureDelegates = configureDelegates ?? (container => { });
        }

        /// <summary>
        /// Creates a container builder from an <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        /// <returns>A container builder that can be used to create an <see cref="IServiceProvider" />.</returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            _configurationAction(builder);

            return builder;
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
