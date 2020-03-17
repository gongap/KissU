using System;
using KissU.Surging.Common.Extensions;

namespace KissU.Surging.Common.ServicesException
{
    /// <summary>
    /// ServiceException. This class cannot be inherited.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public sealed class ServiceException : Exception
    {
        /// <summary>
        /// 初始化 System.Exception 类的新实例。
        /// </summary>
        public ServiceException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 System.Exception 类的新实例。
        /// </summary>
        /// <param name="message">错误信息</param>
        public ServiceException(string message)
            : base(message)
        {
            Message = message;
        }


        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 System.Exception 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="e">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用</param>
        public ServiceException(string message, Exception e)
            : base(message, e)
        {
            Message = string.IsNullOrEmpty(message) ? e.Message : message;
            Source = e.Source;
        }

        /// <summary>
        /// 使用指定的枚举初始化 System.Exception 类的新实例
        /// </summary>
        /// <param name="sysCode">错误号</param>
        public ServiceException(Enum sysCode)
            : base(sysCode.GetDisplay())
        {
            Code = (int) Enum.Parse(sysCode.GetType(), sysCode.ToString());
            Message = sysCode.GetDisplay();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException" /> class.
        /// </summary>
        /// <param name="sysCode">The system code.</param>
        /// <param name="message">The message.</param>
        public ServiceException(Enum sysCode, string message)
        {
            Code = (int) Enum.Parse(sysCode.GetType(), sysCode.ToString());
            Message = string.Format(message, sysCode.GetDisplay());
        }

        /// <summary>
        /// 错误号
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public new string Message { get; set; }

        /// <summary>
        /// 通过自定义错误枚举对象获取ServiceException
        /// </summary>
        /// <typeparam name="T">自定义错误枚举</typeparam>
        /// <returns>返回ServiceException</returns>
        public ServiceException GetServiceException<T>()
        {
            var code = Message.Substring(Message.LastIndexOf("错误号", StringComparison.Ordinal) + 3);
            var sysCode = Enum.Parse(typeof(T), code);
            Code = (int) Enum.Parse(sysCode.GetType(), sysCode.ToString());

            return this;
        }
    }
}