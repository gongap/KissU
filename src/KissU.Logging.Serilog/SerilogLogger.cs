using KissU.Dependency;
using Serilog;
using Serilog.Events;

namespace KissU.Logging.Serilog
{
    /// <summary>
    /// NLogger.
    /// Implements the <see cref="ILogger" />
    /// </summary>
    /// <seealso cref="ILogger" />
    public class SerilogLogger : ILogger
    {
        private readonly ILogger _logger;

        public SerilogLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Write(LogEvent logEvent)
        {
            _logger.Write(logEvent);
            if (logEvent.Level >= LogEventLevel.Error)
            {
               var skyApmLogger = ServiceLocator.GetService<ISkyApmLogger>();
               skyApmLogger?.Error(logEvent.RenderMessage(), logEvent.Exception);
            }
        }
    }
}