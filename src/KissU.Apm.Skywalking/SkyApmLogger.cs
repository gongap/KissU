using System;
using System.Collections.Generic;
using KissU.CPlatform;
using KissU.Logging;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;
using SkyApm.Transport;

namespace KissU.Apm.Skywalking
{

    public class SkyApmLogger : ISkyApmLogger
    {

        private readonly bool _pushSkywalking;
        private readonly IEntrySegmentContextAccessor _entrySegmentContextAccessor;
        private readonly ISkyApmLogDispatcher _skyApmLogDispatcher;
        public SkyApmLogger(IEntrySegmentContextAccessor entrySegmentContextAccessor, ISkyApmLogDispatcher skyApmLogDispatcher)
        {
            _entrySegmentContextAccessor = entrySegmentContextAccessor;
            _skyApmLogDispatcher = skyApmLogDispatcher;
            _pushSkywalking = AppConfig.ServerOptions.PushSkyApmLog;
        }

        public void Debug(string message)
        {
            SendLog("Debug", message);
        }

        public void Error(string message, Exception exception)
        {
            SendLog("Error", message);
        }

        public void Information(string message)
        {
            SendLog("Information", message);
        }

        public void Trace(string message)
        {
            SendLog("Trace", message);
        }

        public void Warning(string message)
        {
            SendLog("Warning", message);
        }

        private void SendLog(string logLevel, string message)
        {
            if (_pushSkywalking && _entrySegmentContextAccessor?.Context != null)
            {
                try
                {
                    var logs = new Dictionary<string, object>();
                    logs.Add("Level", logLevel);
                    logs.Add("logMessage", message);
                    var logContext = new LoggerContext()
                    {
                        Logs = logs,
                        SegmentContext = _entrySegmentContextAccessor.Context,
                        Date = DateTimeOffset.UtcNow.Offset.Ticks
                    };
                    _skyApmLogDispatcher.Dispatch(logContext);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}