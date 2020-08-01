using System;
using Autofac;
using KissU.Extensions;
using KissU.Helpers;
using KissU.Surging.CPlatform;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace KissU.Surging.Nlog
{
    /// <summary>
    /// ServiceHostBuilderExtensions.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Uses the n log.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="nlogConfigFile">The nlog configuration file.</param>
        /// <returns>IServiceHostBuilder.</returns>
        public static IHostBuilder UseNLog(this IHostBuilder hostBuilder,
            string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.AddConfiguration(AppConfig.GetSection("Logging")); });
            return hostBuilder.UseServiceHostBuilder(mapper =>
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
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseNLog(this IHostBuilder hostBuilder, LogLevel minLevel,
            string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.SetMinimumLevel(minLevel); });
            return hostBuilder.UseServiceHostBuilder(mapper =>
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
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder UseNLog(this IHostBuilder hostBuilder,
            Func<string, LogLevel, bool> filter, string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger => { logger.AddFilter(filter); });
            return hostBuilder.UseServiceHostBuilder(mapper =>
            {
                nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                LogManager.LoadConfiguration(nlogConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new NLogProvider());
            });
        }
    }
}