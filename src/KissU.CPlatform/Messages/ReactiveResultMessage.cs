﻿namespace KissU.CPlatform.Messages
{
    public class ReactiveResultMessage
    {
        /// <summary>
        /// 异常消息。
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// 结果内容。
        /// </summary>
        public object Result { get; set; }
    }
}
