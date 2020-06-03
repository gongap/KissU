using System;
using Autofac;
using KissU.Core.Helpers.Utilities;
using KissU.Core.Hosting;
using KissU.Surging.CPlatform;
using KissU.Surging.ServiceHosting.Internal;
using Microsoft.Extensions.Logging;
using NLog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.Surging.Nlog
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class ServiceHostBuilderExtensions
    {
        /// <summary>
        /// Uses the n log.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="nlogConfigFile">The nlog configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseNLog(this IServiceHostBuilder hostBuilder,
            string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); });
            return hostBuilder.Configure(mapper =>
            {
                var section = AppConfig.GetSection("Logging");
                nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                LogManager.LoadConfiguration(nlogConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new NLogProvider());
            });
        }

        /// <summary>
        /// Uses the n log.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="minLevel">The minimum level.</param>
        /// <param name="nlogConfigFile">The nlog configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseNLog(this IServiceHostBuilder hostBuilder, LogLevel minLevel,
            string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.SetMinimumLevel(minLevel); });
            return hostBuilder.Configure(mapper =>
            {
                nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                LogManager.LoadConfiguration(nlogConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new NLogProvider());
            });
        }

        /// <summary>
        /// Uses the n log.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="nlogConfigFile">The nlog configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IServiceHostBuilder UseNLog(this IServiceHostBuilder hostBuilder,
            Func<string, LogLevel, bool> filter, string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.AddFilter(filter); });
            return hostBuilder.Configure(mapper =>
            {
                nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                LogManager.LoadConfiguration(nlogConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new NLogProvider());
            });
        }
    }
}