using System;

namespace KissU.Core.CPlatform.Exceptions
{
    /// <summary>
    /// 基础异常类。
    /// </summary>
    public class CPlatformException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CPlatformException"/> class.
        /// 初始 构造函数
        /// </summary>
        /// <param name="message">异常消息。</param>
        /// <param name="innerException">内部异常。</param>
        public CPlatformException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}