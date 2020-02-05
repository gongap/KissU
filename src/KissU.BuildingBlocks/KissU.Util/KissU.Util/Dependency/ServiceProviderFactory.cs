using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util.Dependency
{
    /// <summary>
    /// A factory for creating a <see cref="ContainerBuilder" /> and an <see cref="IServiceProvider" />.
    /// </summary>
    public class ServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        private readonly ContainerBuilder _builder;
        private readonly Action<ContainerBuilder> _configurationAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory" /> class.
        /// </summary>
        /// <param name="configurationAction">
        /// Action on a <see cref="ContainerBuilder" /> that adds component registrations to
        /// the conatiner.
        /// </param>
        public ServiceProviderFactory(Action<ContainerBuilder> configurationAction = null)
        {
            _configurationAction = configurationAction ?? builder => { };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory" /> class.
        /// </summary>
        /// <param name="builder">Action on a <see cref="ContainerBuilder" /> that adds component registrations to the conatiner.</param>
        public ServiceProviderFactory(ContainerBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Creates a container builder from an <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        /// <returns>A container builder that can be used to create an <see cref="IServiceProvider" />.</returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            var builder = _builder ?? new ContainerBuilder();

            builder.Populate(services);

            _configurationAction?.Invoke(builder);

            return builder;
        }

        /// <summary>
        /// Creates an <see cref="IServiceProvider" /> from the container builder.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        /// <returns>An <see cref="IServiceProvider" />.</returns>
        /// <exception cref="ArgumentNullException">builder</exception>
        public IServiceProvider CreateServiceProvider(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var container = builder.AddUtil();

            return new AutofacServiceProvider(container);
        }
    }
}