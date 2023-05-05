using System;
using JetBrains.Annotations;
using KissU.Dependency;
using KissUtil.Helpers;

namespace KissU.AspNetCore.Internal
{
    public class AppInitializationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public AppInitializationContext([NotNull] IServiceProvider serviceProvider)
        {
            CheckHelper.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}
