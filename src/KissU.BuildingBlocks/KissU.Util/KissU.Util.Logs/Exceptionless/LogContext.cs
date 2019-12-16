using System;
using KissU.Util.Helpers;
using KissU.Util.Logs.Internal;

namespace KissU.Util.Logs.Exceptionless
{
    /// <summary>
    /// Exceptionless日志上下文
    /// </summary>
    public class LogContext : Util.Logs.Core.LogContext
    {
        /// <summary>
        /// 创建日志上下文信息
        /// </summary>
        protected override LogContextInfo CreateInfo()
        {
            return new LogContextInfo
            {
                TraceId = Guid.NewGuid().ToString(),
                Stopwatch = GetStopwatch(),
                Url = Web.Url
            };
        }
    }
}
