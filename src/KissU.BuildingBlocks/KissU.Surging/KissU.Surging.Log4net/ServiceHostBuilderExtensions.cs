using System;
using Autofac;
using KissU.Core.Utilities;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Utilities;
using KissU.Surging.ServiceHosting.Internal;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Log4net
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Uses the log4net.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="log4NetConfigFile">The log4 net configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseLog4net(this IServiceHostBuilder hostBuilder,
            string log4NetConfigFile = "log4net.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); });
            return hostBuilder.MapServices(mapper =>
            {
                var section = AppConfig.GetSection("Logging");
                log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
            });
        }

        /// <summary>
        /// Uses the log4net.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="minLevel">The minimum level.</param>
        /// <param name="log4NetConfigFile">The log4 net configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseLog4net(this IServiceHostBuilder hostBuilder, LogLevel minLevel,
            string log4NetConfigFile = "log4net.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.SetMinimumLevel(minLevel); });
            return hostBuilder.MapServices(mapper =>
            {
                log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
            });
        }

        /// <summary>
        /// Uses the log4net.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="log4NetConfigFile">The log4 net configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseLog4net(this IServiceHostBuilder hostBuilder,
            Func<string, LogLevel, bool> filter, string log4NetConfigFile = "log4net.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.AddFilter(filter); });
            return hostBuilder.MapServices(mapper =>
            {
                log4NetConfigFile = EnvironmentHelper.GetEnvironmentVariable(log4NetConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new Log4NetProvider(log4NetConfigFile));
            });
        }
    }
}