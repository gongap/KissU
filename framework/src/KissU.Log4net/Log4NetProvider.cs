using System.Collections.Concurrent;
using System.IO;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace KissU.Log4net
{
    /// <summary>
    /// Log4NetProvider.
    /// Implements the <see cref="Microsoft.Extensions.Logging.ILoggerProvider" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Logging.ILoggerProvider" />
    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;

        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers =
            new ConcurrentDictionary<string, Log4NetLogger>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetProvider" /> class.
        /// </summary>
        /// <param name="log4NetConfigFile">The log4 net configuration file.</param>
        public Log4NetProvider(string log4NetConfigFile)
        {
            _log4NetConfigFile = log4NetConfigFile;
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

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _loggers.Clear();
        }

        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, Parselog4NetConfigFile(_log4NetConfigFile));
        }

        private static XmlElement Parselog4NetConfigFile(string filename)
        {
            var log4netConfig = new XmlDocument();
            var stream = File.OpenRead(filename);
            log4netConfig.Load(stream);
            stream.Close();
            return log4netConfig["log4net"];
        }
    }
}