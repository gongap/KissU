using System;
using System.IO;
using KissU.CPlatform;
using KissU.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace KissU.Logging.Serilog
{
    /// <summary>
    /// SerilogModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class SerilogModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            var configuration = GetConfiguration();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            serviceProvider.GetInstances<ILoggerFactory>().AddSerilog(new SerilogLogger(Log.Logger));
            serviceProvider.GetInstances<IHostApplicationLifetime>().ApplicationStopped.Register(Log.CloseAndFlush);
        }

        private static IConfiguration GetConfiguration()
        {
            if (File.Exists("serilog.json"))
            {
                var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("serilog.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"serilog.{environment}.json", optional: true, reloadOnChange: true);
                configurationBuilder.AddEnvironmentVariables();
                return configurationBuilder.Build();
            }
           
            return AppConfig.Configuration;
        }
    }
}