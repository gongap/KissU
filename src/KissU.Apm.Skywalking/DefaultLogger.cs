using System;
using Microsoft.Extensions.Logging;
using MSLogger = Microsoft.Extensions.Logging.ILogger;

namespace KissU.Apm.Skywalking
{
    internal class DefaultLogger : SkyApm.Logging.ILogger
    {
        private readonly MSLogger _readLogger;

        public DefaultLogger(MSLogger readLogger)
        {
            _readLogger = readLogger;
        }

        public void Debug(string message)
        {
            _readLogger.LogDebug(message);
        }

        public void Information(string message)
        {
            _readLogger.LogInformation(message);
        }

        public void Warning(string message)
        {
            _readLogger.LogWarning(message);
        }

        public void Error(string message, Exception exception)
        {
            _readLogger.LogError(message + Environment.NewLine + exception);
        }

        public void Trace(string message)
        {
            _readLogger.LogTrace(message);
        }
    }
}