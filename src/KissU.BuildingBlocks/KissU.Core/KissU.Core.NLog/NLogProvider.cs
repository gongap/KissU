using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Nlog
{
    public class NLogProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, NLogger> _loggers =
            new ConcurrentDictionary<string, NLogger>();

        public NLogProvider()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        private NLogger CreateLoggerImplementation(string name)
        {
            return new NLogger(name);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
