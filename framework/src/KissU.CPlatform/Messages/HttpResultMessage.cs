namespace KissU.CPlatform.Messages
{
    /// <summary>
    /// Http结果消息.
    /// Implements the <see cref="HttpResultMessage" />
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <seealso cref="HttpResultMessage" />
    public class HttpResultMessage<T> : HttpResultMessage
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 生成自定义服务数据集
        /// </summary>
        /// <param name="successd">状态值（true:成功 false：失败）</param>
        /// <param name="message">返回到客户端的消息</param>
        /// <param name="result">返回到客户端的数据集</param>
        /// <returns>返回信息结果集</returns>
        public static HttpResultMessage<T> Create(bool successd, string message, T result)
        {
            return new HttpResultMessage<T>
            {
                IsSucceed = successd,
                Message = message,
                Result = result
            };
        }

        /// <summary>
        /// 生成自定义服务数据集
        /// </summary>
        /// <param name="successd">状态值（true:成功 false:失败）</param>
        /// <param name="result">返回到客户端的数据集</param>
        /// <returns>返回信息结果集</returns>
        public static HttpResultMessage<T> Create(bool successd, T result)
        {
            return new HttpResultMessage<T>
            {
                IsSucceed = successd,
                Result = result
            };
        }
    }

    /// <summary>
    /// HttpResultMessage.
    /// Implements the <see cref="HttpResultMessage" />
    /// </summary>
    /// <seealso cref="HttpResultMessage" />
    public class HttpResultMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResultMessage" /> class.
        /// 构造服务数据集
        /// </summary>
        public HttpResultMessage()
        {
            IsSucceed = false;
            Message = string.Empty;
        }

        /// <summary>
        /// 状态值
        /// </summary>
        public bool IsSucceed { get; set; }

        /// <summary>
        /// 返回客户端的消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 生成错误信息
        /// </summary>
        /// <param name="message">返回客户端的消息</param>
        /// <returns>返回服务数据集</returns>
        public static HttpResultMessage Error(string message)
        {
            return new HttpResultMessage {Message = message, IsSucceed = false};
        }

        /// <summary>
        /// 生成服务器数据集
        /// </summary>
        /// <param name="success">状态值（true:成功 false：失败）</param>
        /// <param name="successMessage">返回客户端的消息</param>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>返回服务数据集</returns>
        public static HttpResultMessage Create(bool success, string successMessage = "", string errorMessage = "")
        {
            return new HttpResultMessage {Message = success ? successMessage : errorMessage, IsSucceed = success};
        }
    }
}