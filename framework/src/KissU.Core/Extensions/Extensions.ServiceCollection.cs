using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Abp.Autofac.Extensions
{
    /// <summary>
    /// 系统扩展 - IServiceCollection
    /// </summary>
    public static partial class Extensions
    {

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

        public static IServiceCollection ClearServiceProviderFactories(this IServiceCollection services)
        {
            services.RemoveAll(
                service => service.ImplementationInstance?
                               .GetType()
                               .GetInterfaces()
                               .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IServiceProviderFactory<>)) == true
            );

            return services;
        }

        public static IList<T> RemoveAll<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            List<T> list = source.Where<T>(predicate).ToList<T>();
            foreach (T obj in list)
                source.Remove(obj);
            return (IList<T>)list;
        }
    }
}
