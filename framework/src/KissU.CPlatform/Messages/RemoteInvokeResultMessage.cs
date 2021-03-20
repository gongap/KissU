using KissU.Exceptions;

namespace KissU.CPlatform.Messages
{
    /// <summary>
    /// 远程调用结果消息。
    /// </summary>
    public class RemoteInvokeResultMessage
    {
        /// <summary>
        /// 异常消息。
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 结果内容。
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        public RemoteServiceValidationErrorInfo[] ValidationErrors { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; } = 200;
    }
}