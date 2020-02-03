using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Elasticsearch;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using KissU.Core.ServiceHosting.Internal;

namespace KissU.Core.Serilog
{
    /// <summary>
    /// SerilogModule.
    /// Implements the <see cref="KissU.Core.CPlatform.Module.EnginePartModule" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Module.EnginePartModule" />
    public class SerilogModule: EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
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
            serviceProvider.GetInstances<IApplicationLifetime>().ApplicationStopped.Register(Log.CloseAndFlush);
        }
    }
}