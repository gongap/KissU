using System;
using KissU.Core.Logs.Abstractions;

namespace KissU.Core.Logs.Formats
{
    /// <summary>
    /// 日志格式化提供程序
    /// </summary>
    public class FormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// 日志格式化器
        /// </summary>
        private readonly ILogFormat _format;

        /// <summary>
        /// 初始化日志格式化提供程序
        /// </summary>
        /// <param name="format">日志格式化器</param>
        /// <exception cref="ArgumentNullException">format</exception>
        public FormatProvider(ILogFormat format)
        {
            _format = format ?? throw new ArgumentNullException(nameof(format));
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg" />, formatted as specified by
        /// <paramref name="format" /> and <paramref name="formatProvider" />.
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is ILogContent content))
                return string.Empty;
            return _format.Format(content);
        }

        /// <summary>
        /// 获取格式化器
        /// </summary>
        /// <param name="formatType">Type of the format.</param>
        /// <returns>System.Object.</returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
    }
}