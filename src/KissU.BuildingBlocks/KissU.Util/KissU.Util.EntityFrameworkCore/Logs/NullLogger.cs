using System;
using Microsoft.Extensions.Logging;

namespace KissU.Util.EntityFrameworkCore.Logs
{
    /// <summary>
    /// 空日志记录器
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// 空日志记录器实例
        /// </summary>
        public static readonly ILogger Instance = new NullLogger();

        /// <summary>
        /// 日志记录
        /// </summary>
        /// <typeparam name="TState">The type of the object to be written.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">
        /// Function to create a <see cref="T:System.String" /> message of the <paramref name="state" />
        /// and <paramref name="exception" />.
        /// </param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <returns><c>true</c> if enabled.</returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        /// <summary>
        /// 起始范围
        /// </summary>
        /// <typeparam name="TState">The type of the t state.</typeparam>
        /// <param name="state">The state.</param>
        /// <returns>IDisposable.</returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}