using System;
using JetBrains.Annotations;
using KissU.Dependency;
using KissU.Helpers;

namespace KissU.Modularity
{
    public class ApplicationInitializationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public ApplicationInitializationContext([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}