using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace KissU.Logging.NLog
{
    /// <summary>
    /// NLogProvider.
    /// Implements the <see cref="ILoggerProvider" />
    /// </summary>
    /// <seealso cref="ILoggerProvider" />
    public class NLogProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, NLogger> _loggers =
            new ConcurrentDictionary<string, NLogger>();

        /// <summary>
        /// Creates a new <see cref="T:Microsoft.Extensions.Logging.ILogger" /> instance.
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns>ILogger.</returns>
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _loggers.Clear();
        }

        private NLogger CreateLoggerImplementation(string name)
        {
            return new NLogger(name);
        }
    }
}