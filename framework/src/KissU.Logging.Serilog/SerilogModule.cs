using KissU.CPlatform;
using KissU.Modularity;
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

            var logger = new LoggerConfiguration().ReadFrom.Configuration(AppConfig.Configuration)
                //.WriteTo.RollingFile(new ElasticsearchJsonFormatter(renderMessageTemplate:false),"c:/logs/log-{Date}.log")
                //.WriteTo.Logger(config =>
                //{
                //    //config.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information).ReadFrom.Configuration(AppConfig.Configuration.GetSection("Information"))
                //})
                .CreateLogger();

            serviceProvider.GetInstances<ILoggerFactory>().AddSerilog(logger);
            serviceProvider.GetInstances<IHostApplicationLifetime>().ApplicationStopped.Register(Log.CloseAndFlush);
        }
    }
}