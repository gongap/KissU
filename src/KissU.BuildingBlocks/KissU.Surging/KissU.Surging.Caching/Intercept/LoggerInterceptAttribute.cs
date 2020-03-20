using System;

namespace KissU.Surging.Caching.Intercept
{
    /// <summary>
    /// 设置判断日志拦截方法的特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Interface)]
    public class LoggerInterceptAttribute : Attribute
    {
        #region 字段

        #endregion

        #region 公共属性

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化一个新的<c>InterceptMethodAttribute</c>类型。
        /// </summary>
        /// <param name="message">The message.</param>
        public LoggerInterceptAttribute(string message)
        {
            Message = message;
        }

        /// <summary>
        /// 初始化一个新的<c>InterceptMethodAttribute</c>类型。
        /// </summary>
        public LoggerInterceptAttribute()
            : this(null)
        {
        }

        #endregion
    }
}