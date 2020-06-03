using System;
using KissU.Properties;

namespace KissU.Core.Helpers.Utilities
{
    /// <summary>
    /// 校验
    /// </summary>
    public sealed class Check
    {
        /// <summary>
        /// 不为空
        /// </summary>
        /// <typeparam name="T">输入值类型</typeparam>
        /// <param name="value">输入值</param>
        /// <param name="parameterName">参数</param>
        /// <returns>输入值</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T NotNull<T>(T value, string parameterName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        /// <summary>
        /// 不为空
        /// </summary>
        /// <typeparam name="T">可空输入值类型</typeparam>
        /// <param name="value">可空输入值</param>
        /// <param name="parameterName">参数</param>
        /// <returns>可空输入值</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T? NotNull<T>(T? value, string parameterName)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        /// <summary>
        /// 不为空
        /// </summary>
        /// <param name="value">输入值</param>
        /// <param name="parameterName">参数</param>
        /// <returns>输入值</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException">
        /// Initializes a new instance of the System.ArgumentNullException class with the
        /// name of the parameter that causes this exception
        /// </exception>
        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(LibraryResource.ArgumentIsNullOrWhitespace, parameterName));
            }

            return value;
        }

        /// <summary>
        /// 校验条件
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="parameterName">参数名</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException">
        /// Initializes a new instance of the System.ArgumentNullException class with the
        /// name of the parameter that causes this exception
        /// </exception>
        public static void CheckCondition(Func<bool> condition, string parameterName)
        {
            if (condition.Invoke())
            {
                throw new ArgumentException(string.Format(LibraryResource.ArgumentIsNullOrWhitespace, parameterName));
            }
        }

        /// <summary>
        /// 校验条件
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="formatErrorText">格式化错误文本</param>
        /// <param name="parameters">参数数组</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException">
        /// Initializes a new instance of the System.ArgumentNullException class with the
        /// name of the parameter that causes this exception
        /// </exception>
        public static void CheckCondition(Func<bool> condition, string formatErrorText, params string[] parameters)
        {
            if (condition.Invoke())
            {
                throw new ArgumentException(string.Format(LibraryResource.ArgumentIsNullOrWhitespace, parameters));
            }
        }
    }
}