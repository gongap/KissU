namespace KissU.Util.Logs.Aspects
{
    /// <summary>
    /// 调试日志
    /// </summary>
    public class DebugLogAttribute : LogAttributeBase
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="log">The log.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool Enabled(ILog log)
        {
            return log.IsDebugEnabled;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">The log.</param>
        protected override void WriteLog(ILog log)
        {
            log.Debug();
        }
    }
}