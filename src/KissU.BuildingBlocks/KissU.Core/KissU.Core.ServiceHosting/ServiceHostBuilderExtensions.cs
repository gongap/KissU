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
    /// 服务主机生成器扩展.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// 使用启动类
        /// </summary>
        /// <param name="hostBuilder">主机构建器</param>
        /// <param name="startupType">启动类型</param>
        /// <returns>服务主机生成器.</returns>
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
                            return new ConventionBasedStartup(StartupLoader.LoadMethods(sp, config, startupType, string.Empty));
                        });
                    }
                });
        }

        /// <summary>
        /// 使用启动类
        /// </summary>
        /// <typeparam name="TStartup">启动类型</typeparam>
        /// <param name="hostBuilder">主机构建器</param>
        /// <returns>主机构建器</returns>
        public static IServiceHostBuilder UseStartup<TStartup>(this IServiceHostBuilder hostBuilder)
            where TStartup : class
        {
            return hostBuilder.UseStartup(typeof(TStartup));
        }

        /// <summary>
        /// 使用控制台生命周期
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IServiceHostBuilder.</returns>
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