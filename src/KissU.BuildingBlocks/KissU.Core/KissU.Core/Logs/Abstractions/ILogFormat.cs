namespace KissU.Core.Logs.Abstractions
{
    /// <summary>
    /// 日志格式器
    /// </summary>
    public interface ILogFormat
    {
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <returns>System.String.</returns>
        string Format(ILogContent content);
    }
}