using System;

namespace KissU.Core.Exceptions
{
    /// <summary>
    /// 注册连接异常.
    /// Implements the <see cref="CPlatformException" />
    /// </summary>
    /// <seealso cref="CPlatformException" />
    public class RegisterConnectionException : CPlatformException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterConnectionException" /> class.
        /// </summary>
        /// <param name="message">异常消息。</param>
        /// <param name="innerException">内部异常。</param>
        public RegisterConnectionException(string message, Exception innerException = null) : base(message,
            innerException)
        {
        }
    }
}