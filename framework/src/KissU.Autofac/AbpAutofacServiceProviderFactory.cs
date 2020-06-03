using System;
using Autofac;
using KissU.Autofac.Extensions.DependencyInjection;
using KissU.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Autofac
{
    /// <summary>
    /// A factory for creating a <see cref="T:Autofac.ContainerBuilder" /> and an <see cref="T:System.IServiceProvider" />.
    /// </summary>
    public class AbpAutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        private readonly ContainerBuilder _builder;
        private IServiceCollection _services;

        public AbpAutofacServiceProviderFactory(ContainerBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Creates a container builder from an <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <returns>A container builder that can be used to create an <see cref="T:System.IServiceProvider" />.</returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            _services = services;

            _builder.Populate(services);

            return _builder;
        }

        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            if (containerBuilder == null) throw new ArgumentNullException(nameof(containerBuilder));

            var container = containerBuilder.Build();

            ServiceLocator.Current = container;

            return new AutofacServiceProvider(container);
        }
    }
}