using System;

namespace KissU.Core.CPlatform.Exceptions
{
    /// <summary>
    /// 远程执行异常（由服务端转发至客户端的异常信息）。
    /// </summary>
    public class CPlatformCommunicationException : CPlatformException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CPlatformCommunicationException" /> class.
        /// 初始化构造函数
        /// </summary>
        /// <param name="message">异常消息。</param>
        /// <param name="StatusCode">The status code.</param>
        /// <param name="innerException">内部异常。</param>
        public CPlatformCommunicationException(string message,int StatusCode=0, Exception innerException = null)
            : base(message, innerException)
        {
            HResult = StatusCode;
        }
    }
}