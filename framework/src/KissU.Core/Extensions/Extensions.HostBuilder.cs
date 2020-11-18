using System;
using Autofac;
using KissU.ServiceHosting;
using Microsoft.Extensions.Hosting;

namespace KissU.Extensions
{
    /// <summary>
    /// 系统扩展 - IHostBuilder
    /// </summary>
    public static partial class Extensions
    {
        public static IHostBuilder ConfigureMicroServiceHost(this IHostBuilder hostBuilder, Action<IContainer> configureDelegates = null)
        {
            return ConfigureMicroServiceHost(hostBuilder, null, configureDelegates);
        }

        public static IHostBuilder ConfigureMicroServiceHost(this IHostBuilder hostBuilder, Action<ContainerBuilder> configurationAction, Action<IContainer> configureDelegates = null)
        {
            var serviceHostBuilder = hostBuilder is IServiceHostBuilder builder ? builder : new ServiceHostBuilder(hostBuilder);
            if (configurationAction != null)
            {
                serviceHostBuilder.ConfigureContainer(configurationAction);
            }

            if (configureDelegates != null)
            {
                serviceHostBuilder.Configure(configureDelegates);
            }

            return serviceHostBuilder;
        }
    }
}
