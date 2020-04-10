namespace KissU.Core.Logs.Aspects
{
    /// <summary>
    /// 跟踪日志
    /// </summary>
    public class TraceLogAttribute : LogAttributeBase
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="log">The log.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool Enabled(ILog log)
        {
            return log.IsTraceEnabled;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">The log.</param>
        protected override void WriteLog(ILog log)
        {
            log.Trace();
        }
    }
}