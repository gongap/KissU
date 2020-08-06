using System;

namespace KissU.Caching.Utilities
{
    /// <summary>
    /// Check. This class cannot be inherited.
    /// </summary>
    public sealed class Check
    {
        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        /// <summary>
        /// Nots the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T? NotNull<T>(T? value, string parameterName) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        /// <summary>
        /// Nots the empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(CachingResources.ArgumentIsNullOrWhitespace, parameterName));
            }

            return value;
        }

        /// <summary>
        /// Checks the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckCondition(Func<bool> condition, string parameterName)
        {
            if (condition.Invoke())
            {
                throw new ArgumentException(string.Format(CachingResources.ArgumentIsNullOrWhitespace, parameterName));
            }
        }

        /// <summary>
        /// Checks the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="formatErrorText">The format error text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckCondition(Func<bool> condition, string formatErrorText, params string[] parameters)
        {
            if (condition.Invoke())
            {
                throw new ArgumentException(string.Format(CachingResources.ArgumentIsNullOrWhitespace, parameters));
            }
        }
    }
}