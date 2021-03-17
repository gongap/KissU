using System;

namespace KissU.Exceptions.Prompts
{
    /// <summary>
    /// 异常提示
    /// </summary>
    public interface IExceptionPrompt
    {
        /// <summary>
        /// 获取异常提示
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="includeSensitiveDetails">应包含错误信息的敏感详细信息</param>
        /// <returns>System.String.</returns>
        string GetPrompt(Exception exception, bool includeSensitiveDetails);
    }
}