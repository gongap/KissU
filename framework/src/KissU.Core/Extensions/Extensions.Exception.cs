using System;

namespace KissU.Extensions
{
    /// <summary>
    /// 异常扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 获取原始异常
        /// </summary>
        /// <param name="exception">异常</param>
        public static Exception GetRawException(this Exception exception)
        {
            if (exception == null)
                return null;
            if (exception.InnerException == null)
                return exception;
            return GetRawException(exception.InnerException);
        }
    }
}
