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
        public static IHostBuilder Configure(this IHostBuilder hostBuilder, Action<IContainer> configureDelegates)
        {
            return UseServiceHostBuilder(hostBuilder, null, configureDelegates);
        }

        public static IHostBuilder ConfigureContainer(this IHostBuilder hostBuilder, Action<ContainerBuilder> configurationAction)
        {
            return UseServiceHostBuilder(hostBuilder, configurationAction, null);
        }

        public static IHostBuilder UseServiceHostBuilder(this IHostBuilder hostBuilder, Action<ContainerBuilder> configurationAction = null, Action<IContainer> configureDelegates = null)
        {
            var serviceHostBuilder = hostBuilder is IServiceHostBuilder builder ? builder : new ServiceHostBuilder(hostBuilder);
            if (configurationAction != null)
            {
                serviceHostBuilder.ConfigureContainer(configurationAction);
            }

            if(configureDelegates != null)
            {
                serviceHostBuilder.Configure(configureDelegates);
            }

            return serviceHostBuilder;
        }
    }
}
