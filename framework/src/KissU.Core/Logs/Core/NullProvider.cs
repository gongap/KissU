using KissU.Core.Logs.Abstractions;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Logs.Core
{
    /// <summary>
    /// 日志提供程序
    /// </summary>
    public class NullProvider : ILogProvider
    {
        /// <summary>
        /// 初始化日志
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <param name="format">日志格式化器</param>
        public NullProvider(string logName, ILogFormat format = null)
        {
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName => nameof(NullLogger);

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => false;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => false;

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="content">日志内容</param>
        public void WriteLog(LogLevel level, ILogContent content)
        {
        }

        /// <summary>
        /// 获取NLog日志操作
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <returns>ILogger.</returns>
        public static ILogger GetLogger(string logName)
        {
            try
            {
                return Helpers.Ioc.Create<ILogger>();
            }
            catch
            {
                return NullLogger.Instance;
            }
        }
    }
}