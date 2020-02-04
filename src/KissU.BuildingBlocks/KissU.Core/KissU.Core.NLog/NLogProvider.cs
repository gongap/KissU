using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Nlog
{
    /// <summary>
    /// NLogProvider.
    /// Implements the <see cref="Microsoft.Extensions.Logging.ILoggerProvider" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Logging.ILoggerProvider" />
    public class NLogProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, NLogger> _loggers =
            new ConcurrentDictionary<string, NLogger>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogProvider"/> class.
        /// </summary>
        public NLogProvider()
        {
        }

        /// <summary>
        /// Creates a new <see cref="T:Microsoft.Extensions.Logging.ILogger" /> instance.
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns>ILogger.</returns>
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        private NLogger CreateLoggerImplementation(string name)
        {
            return new NLogger(name);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
