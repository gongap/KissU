using System;
using Autofac;
using Microsoft.Extensions.Hosting;

namespace KissU.ServiceHosting
{
    /// <summary>
    /// Provides convenience methods for creating instances of <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" /> with pre-configured defaults.
    /// </summary>
    public static class ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.Extensions.Hosting.HostBuilder" /> class with pre-configured defaults.
        /// </summary>
        /// <remarks>
        ///   The following defaults are applied to the returned <see cref="T:Microsoft.Extensions.Hosting.HostBuilder" />:
        ///   <list type="bullet">
        ///     <item><description>set the <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath" /> to the result of <see cref="M:System.IO.Directory.GetCurrentDirectory" /></description></item>
        ///     <item><description>load host <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from "DOTNET_" prefixed environment variables</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from 'appsettings.json' and 'appsettings.[<see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" />].json'</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from User Secrets when <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" /> is 'Development' using the entry assembly</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from environment variables</description></item>
        ///     <item><description>configure the <see cref="T:Microsoft.Extensions.Logging.ILoggerFactory" /> to log to the console, debug, and event source output</description></item>
        ///     <item><description>enables scope validation on the dependency injection container when <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" /> is 'Development'</description></item>
        ///   </list>
        /// </remarks>
        /// <param name="configurationAction">configurationAction</param>
        /// <returns>The initialized <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" />.</returns>
        public static IServiceHostBuilder CreateDefaultBuilder(Action<IHostBuilder> configurationAction = null)
        {
            return CreateDefaultBuilder(null, configurationAction);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.Extensions.Hosting.HostBuilder" /> class with pre-configured defaults.
        /// </summary>
        /// <remarks>
        ///   The following defaults are applied to the returned <see cref="T:Microsoft.Extensions.Hosting.HostBuilder" />:
        ///   <list type="bullet">
        ///     <item><description>set the <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath" /> to the result of <see cref="M:System.IO.Directory.GetCurrentDirectory" /></description></item>
        ///     <item><description>load host <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from "DOTNET_" prefixed environment variables</description></item>
        ///     <item><description>load host <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from supplied command line args</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from 'appsettings.json' and 'appsettings.[<see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" />].json'</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from User Secrets when <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" /> is 'Development' using the entry assembly</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from environment variables</description></item>
        ///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from supplied command line args</description></item>
        ///     <item><description>configure the <see cref="T:Microsoft.Extensions.Logging.ILoggerFactory" /> to log to the console, debug, and event source output</description></item>
        ///     <item><description>enables scope validation on the dependency injection container when <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" /> is 'Development'</description></item>
        ///   </list>
        /// </remarks>
        /// <param name="args">The command line args.</param>
        /// <param name="configurationAction">configurationAction</param>
        /// <returns>The initialized <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" />.</returns>
        public static IServiceHostBuilder CreateDefaultBuilder(string[] args, Action<IHostBuilder> configurationAction = null)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            configurationAction?.Invoke(hostBuilder);
            return new ServiceHostBuilder(hostBuilder);
        }
    }
}
