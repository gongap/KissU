using System.IO;
using KissU.CPlatform;
using KissU.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

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
            var exceptionlessOption = new ExceptionlessOption();
           var section = AppConfig.GetSection("Exceptionless");
            if (section.Exists())
            {
                exceptionlessOption = section.Get<ExceptionlessOption>();
            }

            var logger = new LoggerConfiguration().ReadFrom.Configuration(AppConfig.Configuration)
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Async(c => c.File(Path.Combine(Directory.GetCurrentDirectory(), "logs/logs.txt")))
                .WriteTo.Exceptionless(exceptionlessOption.ApiKey, exceptionlessOption.ServerUrl)
                .CreateLogger();

            serviceProvider.GetInstances<ILoggerFactory>().AddSerilog(logger);
            serviceProvider.GetInstances<IHostApplicationLifetime>().ApplicationStopped.Register(Log.CloseAndFlush);
        }
    }
}