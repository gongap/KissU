using System;
using System.Reflection;
using KissU.Core.ServiceHosting.Internal;
using KissU.Core.ServiceHosting.Internal.Implementation;
using KissU.Core.ServiceHosting.Startup;
using KissU.Core.ServiceHosting.Startup.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.ServiceHosting
{
    /// <summary>
    /// 服务主机生成器扩展
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="startupType"></param>
        /// <returns></returns>
        public static IServiceHostBuilder UseStartup(this IServiceHostBuilder hostBuilder, Type startupType)
        {
            return hostBuilder
                .ConfigureServices(services =>
                {
                    if (typeof(IStartup).GetTypeInfo().IsAssignableFrom(startupType.GetTypeInfo()))
                    {
                        services.AddSingleton(typeof(IStartup), startupType);
                    }
                    else
                    {
                        services.AddSingleton(typeof(IStartup), sp =>
                        {
                            var config = sp.GetService<IConfigurationBuilder>();
                            return new ConventionBasedStartup(StartupLoader.LoadMethods(sp, config, startupType, ""));
                        });
                    }
                });
        }

        public static IServiceHostBuilder UseStartup<TStartup>(this IServiceHostBuilder hostBuilder)
            where TStartup : class
        {
            return hostBuilder.UseStartup(typeof(TStartup));
        }

        public static IServiceHostBuilder UseConsoleLifetime(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(collection =>
            {
                collection.AddSingleton<IApplicationLifetime, ApplicationLifetime>();
                collection.AddSingleton<IHostLifetime, ConsoleLifetime>();
            });
        }
    }
}
