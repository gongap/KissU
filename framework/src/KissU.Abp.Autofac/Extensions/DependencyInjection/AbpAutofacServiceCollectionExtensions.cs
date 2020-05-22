using System;
using Autofac;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Abp.Autofac.Extensions.DependencyInjection
{
    public static class AbpAutofacServiceCollectionExtensions
    {
        [NotNull]
        public static ContainerBuilder GetContainerBuilder([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            var builder = services.GetObjectOrNull<ContainerBuilder>();
            if (builder == null)
            {
                throw new AbpException($"Could not find ContainerBuilder. Be sure that you have called {nameof(AbpAutofacAbpApplicationCreationOptionsExtensions.UseAutofac)} method before!");
            }

            return builder;
        }

        public static IServiceProvider BuildAutofacServiceProvider([NotNull] this IServiceCollection services, Action<ContainerBuilder> builderAction = null)
        {
	        return services.BuildServiceProviderFromFactory(builderAction);
        }
	}
}
