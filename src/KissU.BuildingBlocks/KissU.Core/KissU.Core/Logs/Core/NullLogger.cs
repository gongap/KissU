using System;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Logs.Core
{
    /// <summary>
    /// 一个空的日志记录器。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class NullLogger<T> : NullLogger, ILogger<T>
    {
    }

    /// <summary>
    /// 一个空的日志记录器。
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static NullLogger Instance { get; } = new NullLogger();

        #region Implementation of ILogger

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TState">The type of the object to be written.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">
        /// Function to create a <c>string</c> message of the <paramref name="state" /> and
        /// <paramref name="exception" />.
        /// </param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
        }

        /// <summary>
        /// Checks if the given <paramref name="logLevel" /> is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns><c>true</c> if enabled.</returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <typeparam name="TState">The type of the t state.</typeparam>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        #endregion Implementation of ILogger
    }
}