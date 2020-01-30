using System;

namespace KissU.Core.CPlatform.Exceptions
{
    /// <summary>
    /// 对象校验异常
    /// </summary>
    public class ValidateException : CPlatformException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateException" /> class.
        /// 初始构造函数
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        public ValidateException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}