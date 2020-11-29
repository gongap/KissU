using System;
using Autofac;
using Microsoft.Extensions.Hosting;

namespace KissU.Extensions
{
    /// <summary>
    /// 系统扩展 - IHostBuilder
    /// </summary>
    public static partial class Extensions
    {
        public static IHostBuilder ConfigureContainer(this IHostBuilder hostBuilder, Action<ILifetimeScope> configureDelegates)
        {
            return ConfigureContainer(hostBuilder, null, configureDelegates);
        }

        public static IHostBuilder ConfigureContainer(this IHostBuilder hostBuilder, Action<ContainerBuilder> configurationAction)
        {
            return hostBuilder.ConfigureContainer(configurationAction, null);
        }

        public static IHostBuilder ConfigureContainer(this IHostBuilder hostBuilder, Action<ContainerBuilder> configurationAction = null, Action<ILifetimeScope> configureDelegates = null)
        {
            if (configurationAction != null)
            {
                hostBuilder.ConfigureContainer<ContainerBuilder>(configurationAction);
            }

            if (configureDelegates != null)
            {
                hostBuilder.ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterBuildCallback(configureDelegates);
                });
            }

            return hostBuilder;
        }
    }
}
