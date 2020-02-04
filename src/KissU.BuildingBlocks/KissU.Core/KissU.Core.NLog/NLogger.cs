﻿using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Nlog
{
    /// <summary>
    /// NLogger.
    /// Implements the <see cref="Microsoft.Extensions.Logging.ILogger" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Logging.ILogger" />
    public class NLogger : ILogger
    {
        private readonly NLog.Logger _log;
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogger"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public NLogger(string name)
        { 
            _log = NLog.LogManager.GetLogger(name);
        }

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <typeparam name="TState">The type of the t state.</typeparam>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        /// <summary>
        /// Checks if the given <paramref name="logLevel" /> is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns><c>true</c> if enabled.</returns>
        /// <exception cref="ArgumentOutOfRangeException">logLevel</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    return _log.IsFatalEnabled;
                case LogLevel.Debug:
                    return _log.IsDebugEnabled;
                case LogLevel.Trace:
                    return _log.IsTraceEnabled;
                case LogLevel.Error:
                    return _log.IsErrorEnabled;
                case LogLevel.Information:
                    return _log.IsInfoEnabled;
                case LogLevel.Warning:
                    return _log.IsWarnEnabled;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel));
            }
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TState">The type of the t state.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a <c>string</c> message of the <paramref name="state" /> and <paramref name="exception" />.</param>
        /// <exception cref="ArgumentNullException">formatter</exception>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            string message = null;
            if (null != formatter)
            {
                message = formatter(state, exception);
            }
            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                switch (logLevel)
                {
                    case LogLevel.Critical:
                        _log.Fatal(message);
                        break;
                    case LogLevel.Debug:
                        _log.Debug(message);
                        break;
                    case LogLevel.Trace:
                        _log.Trace(message);
                        break;
                    case LogLevel.Error:
                        _log.Error(message, exception,null);
                        break;
                    case LogLevel.Information:
                        _log.Info(message);
                        break;
                    case LogLevel.Warning:
                        _log.Warn(message);
                        break;
                    default:
                        _log.Warn($"遇到未知日志级别{logLevel}");
                        _log.Info(message, exception,null);
                        break;
                }
            }
        }

        /// <summary>
        /// NoopDisposable.
        /// Implements the <see cref="System.IDisposable" />
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        private class NoopDisposable : IDisposable
        {
            /// <summary>
            /// The instance
            /// </summary>
            public static NoopDisposable Instance = new NoopDisposable();

            /// <summary>
            /// Disposes this instance.
            /// </summary>
            public void Dispose()
            {
               
            }
        }
    }
}
