using System;

namespace KissU.Exceptions
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
        /// <param name="innerException">内部异常。</param>
        public CPlatformCommunicationException(string message, string code = null,  string details = null, RemoteServiceValidationErrorInfo[] validationErrors = null, Exception innerException = null, int? statusCode = null)
            : base(message, innerException)
        {
            Code = code;
            Details = details;
            ValidationErrors = validationErrors;
            if (statusCode.HasValue)
            {
                HResult = statusCode.Value;
            }
        }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        public RemoteServiceValidationErrorInfo[] ValidationErrors { get; set; }
    }
}