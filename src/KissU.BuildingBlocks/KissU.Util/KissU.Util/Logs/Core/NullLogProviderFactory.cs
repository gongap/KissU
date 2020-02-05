using KissU.Util.Logs.Abstractions;

namespace KissU.Util.Logs.Core
{
    /// <summary>
    /// 日志提供程序工厂
    /// </summary>
    public class NullLogProviderFactory : ILogProviderFactory
    {
        /// <summary>
        /// 创建日志提供程序
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <param name="format">日志格式化器</param>
        /// <returns>ILogProvider.</returns>
        public ILogProvider Create(string logName, ILogFormat format = null)
        {
            return new NullProvider(logName, format);
        }
    }
}