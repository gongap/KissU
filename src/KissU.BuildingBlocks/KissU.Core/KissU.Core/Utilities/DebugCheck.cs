using System.Diagnostics;

namespace KissU.Core.Utilities
{
    /// <summary>
    /// 调试检查。这个类不能被继承.
    /// </summary>
    public sealed class DebugCheck
    {
        /// <summary>
        /// 不是null.
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="value">The value.</param>
        [Conditional("DEBUG")]
        public static void NotNull<T>(T value)
            where T : class
        {
            Debug.Assert(value != null, "NotNull");
        }

        /// <summary>
        /// 不是null.
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="value">The value.</param>
        [Conditional("DEBUG")]
        public static void NotNull<T>(T? value)
            where T : struct
        {
            Debug.Assert(value != null, "NotNull");
        }

        /// <summary>
        /// 不是空.
        /// </summary>
        /// <param name="value">The value.</param>
        [Conditional("DEBUG")]
        public static void NotEmpty(string value)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(value), "NotEmpty");
        }
    }
}