using System;
using Autofac;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.ServiceHosting.Internal;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Nlog
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
        public static IServiceHostBuilder UseNLog(this IServiceHostBuilder hostBuilder, string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger =>
            {
                logger.AddConfiguration(CPlatform.AppConfig.GetSection("Logging"));
            });
            return hostBuilder.MapServices(mapper =>
            {
                var section = CPlatform.AppConfig.GetSection("Logging");
                nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                NLog.LogManager.LoadConfiguration(nlogConfigFile);
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
        public static IServiceHostBuilder UseNLog(this IServiceHostBuilder hostBuilder, LogLevel minLevel, string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger =>
            {
                logger.SetMinimumLevel(minLevel);
            });
            return hostBuilder.MapServices(mapper =>
            {
                nlogConfigFile =EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                NLog.LogManager.LoadConfiguration(nlogConfigFile);
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
        public static IServiceHostBuilder UseNLog(this IServiceHostBuilder hostBuilder, Func<string, LogLevel, bool> filter, string nlogConfigFile = "nLog.config")
        {
            hostBuilder.ConfigureLogging(logger =>
            {
                logger.AddFilter(filter);
            });
            return hostBuilder.MapServices(mapper =>
            {
                nlogConfigFile = EnvironmentHelper.GetEnvironmentVariable(nlogConfigFile);
                NLog.LogManager.LoadConfiguration(nlogConfigFile);
                mapper.Resolve<ILoggerFactory>().AddProvider(new NLogProvider());
            });
        }
    }
}
