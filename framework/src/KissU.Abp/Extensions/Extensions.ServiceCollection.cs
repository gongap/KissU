using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Abp.Extensions
{
    /// <summary>
    /// 系统扩展 - IServiceCollection
    /// </summary>
    public static partial class Extensions
    {
        [NotNull]
        public static ContainerBuilder GetContainerBuilder([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            var builder = services.GetObjectOrNull<ContainerBuilder>();
            if (builder == null)
            {
                throw new AbpException($"Could not find ContainerBuilder. Be sure that you have called {nameof(UseAutofac)} method before!");
            }

            return builder;
        }

        public static IServiceProvider BuildAutofacServiceProvider([NotNull] this IServiceCollection services, Action<ContainerBuilder> builderAction = null)
        {
	        return services.BuildServiceProviderFromFactory(builderAction);
        }

        /// <summary>
        /// Adds the <see cref="AutofacServiceProviderFactory"/> to the service collection.
        /// </summary>
        /// <param name="services">The service collection to add the factory to.</param>
        /// <param name="configurationAction">Action on a <see cref="ContainerBuilder"/> that adds component registrations to the container.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddAutofac(this IServiceCollection services, Action<ContainerBuilder> configurationAction = null)
        {
            return services
                .ClearServiceProviderFactories()
                .AddSingleton<IServiceProviderFactory<ContainerBuilder>>(new AutofacServiceProviderFactory(configurationAction));
        }

        private static IServiceCollection ClearServiceProviderFactories([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            services.RemoveAll(
                service => service.ImplementationInstance?
                               .GetType()
                               .GetInterfaces()
                               .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IServiceProviderFactory<>)) == true
            );

            return services;
        }
    }
}
