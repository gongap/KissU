using Serilog.Core;
using Serilog.Events;

namespace KissU.Serilog
{
    /// <summary>
    /// SerilogVerboseFilter.
    /// Implements the <see cref="ILogEventFilter" />
    /// </summary>
    /// <seealso cref="ILogEventFilter" />
    public class SerilogVerboseFilter : ILogEventFilter
    {
        /// <summary>
        /// Returns true if the provided event is enabled. Otherwise, false.
        /// </summary>
        /// <param name="logEvent">The event to test.</param>
        /// <returns>
        /// True if the event is enabled by this filter. If false
        /// is returned, the event will not be emitted.
        /// </returns>
        public bool IsEnabled(LogEvent logEvent)
        {
            return logEvent.Level == LogEventLevel.Verbose;
        }
    }

    /// <summary>
    /// SerilogDebugFilter.
    /// Implements the <see cref="ILogEventFilter" />
    /// </summary>
    /// <seealso cref="ILogEventFilter" />
    public class SerilogDebugFilter : ILogEventFilter
    {
        /// <summary>
        /// Returns true if the provided event is enabled. Otherwise, false.
        /// </summary>
        /// <param name="logEvent">The event to test.</param>
        /// <returns>
        /// True if the event is enabled by this filter. If false
        /// is returned, the event will not be emitted.
        /// </returns>
        public bool IsEnabled(LogEvent logEvent)
        {
            return logEvent.Level == LogEventLevel.Debug;
        }
    }

    /// <summary>
    /// SerilogErrorFilter.
    /// Implements the <see cref="ILogEventFilter" />
    /// </summary>
    /// <seealso cref="ILogEventFilter" />
    public class SerilogErrorFilter : ILogEventFilter
    {
        /// <summary>
        /// Returns true if the provided event is enabled. Otherwise, false.
        /// </summary>
        /// <param name="logEvent">The event to test.</param>
        /// <returns>
        /// True if the event is enabled by this filter. If false
        /// is returned, the event will not be emitted.
        /// </returns>
        public bool IsEnabled(LogEvent logEvent)
        {
            return logEvent.Level == LogEventLevel.Error;
        }
    }

    /// <summary>
    /// SerilogFatalFilter.
    /// Implements the <see cref="ILogEventFilter" />
    /// </summary>
    /// <seealso cref="ILogEventFilter" />
    public class SerilogFatalFilter : ILogEventFilter
    {
        /// <summary>
        /// Returns true if the provided event is enabled. Otherwise, false.
        /// </summary>
        /// <param name="logEvent">The event to test.</param>
        /// <returns>
        /// True if the event is enabled by this filter. If false
        /// is returned, the event will not be emitted.
        /// </returns>
        public bool IsEnabled(LogEvent logEvent)
        {
            return logEvent.Level == LogEventLevel.Fatal;
        }
    }

    /// <summary>
    /// SerilogInformationFilter.
    /// Implements the <see cref="ILogEventFilter" />
    /// </summary>
    /// <seealso cref="ILogEventFilter" />
    public class SerilogInformationFilter : ILogEventFilter
    {
        /// <summary>
        /// Returns true if the provided event is enabled. Otherwise, false.
        /// </summary>
        /// <param name="logEvent">The event to test.</param>
        /// <returns>
        /// True if the event is enabled by this filter. If false
        /// is returned, the event will not be emitted.
        /// </returns>
        public bool IsEnabled(LogEvent logEvent)
        {
            return logEvent.Level == LogEventLevel.Information;
        }
    }

    /// <summary>
    /// SerilogWarningFilter.
    /// Implements the <see cref="ILogEventFilter" />
    /// </summary>
    /// <seealso cref="ILogEventFilter" />
    public class SerilogWarningFilter : ILogEventFilter
    {
        /// <summary>
        /// Returns true if the provided event is enabled. Otherwise, false.
        /// </summary>
        /// <param name="logEvent">The event to test.</param>
        /// <returns>
        /// True if the event is enabled by this filter. If false
        /// is returned, the event will not be emitted.
        /// </returns>
        public bool IsEnabled(LogEvent logEvent)
        {
            return logEvent.Level == LogEventLevel.Warning;
        }
    }
}