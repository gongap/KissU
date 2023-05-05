using System;
using JetBrains.Annotations;
using KissU.Dependency;
using KissUtil.Helpers;

namespace KissU.AspNetCore.Internal
{
    public class ApplicationInitializationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public ApplicationInitializationContext([NotNull] IServiceProvider serviceProvider)
        {
            CheckHelper.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}