using System;

namespace KissU.Logging
{
    public class NullSkyApmLogger : ISkyApmLogger
    {
        public void Debug(string message)
        {
        }

        public void Information(string message)
        {
        }

        public void Warning(string message)
        {
        }

        public void Error(string message, Exception exception)
        {
        }

        public void Trace(string message)
        {
        }
    }
}