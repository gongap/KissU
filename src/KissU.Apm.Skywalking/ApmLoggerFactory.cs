using System;
using KissU.Dependency;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using SkyApm.Config;
using SkyApm.Utilities.Logging;

namespace KissU.Apm.Skywalking
{
    public class ApmLoggerFactory : SkyApm.Logging.ILoggerFactory
    {
        private const string outputTemplate =
            @"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{ServiceName}] [{Level}] {SourceContext} : {Message}{NewLine}{Exception}";

        private readonly ILoggerFactory _loggerFactory;
        private readonly LoggingConfig _loggingConfig;

        public ApmLoggerFactory(IConfigAccessor configAccessor)
        {
            _loggingConfig = configAccessor.Get<LoggingConfig>();
            //_loggerFactory = new MSLoggerFactory();
            _loggerFactory = ServiceLocator.GetService<ILoggerFactory>();
            //var instrumentationConfig = configAccessor.Get<InstrumentConfig>();

            //var level = EventLevel(_loggingConfig.Level);

            //_loggerFactory.AddSerilog(new LoggerConfiguration().MinimumLevel.Verbose().Enrich
            //    .WithProperty("SourceContext", null).Enrich
            //    .WithProperty(nameof(instrumentationConfig.ServiceName),
            //        instrumentationConfig.ServiceName ?? instrumentationConfig.ApplicationCode).Enrich
            //    .FromLogContext()
            //    .WriteTo.RollingFile(_loggingConfig.FilePath, level, outputTemplate, null, 1073741824,31, null, false, false, TimeSpan.FromMilliseconds(500))
            //    .WriteTo.Console(LogEventLevel.Debug)
            //    .CreateLogger());
        }

        public SkyApm.Logging.ILogger CreateLogger(Type type)
        {
            return new DefaultLogger(_loggerFactory.CreateLogger(type));
        }

        private static LogEventLevel EventLevel(string level)
        {
            return LogEventLevel.TryParse<LogEventLevel>(level, out var logEventLevel)
                ? logEventLevel
                : LogEventLevel.Error;
        }
    }
}