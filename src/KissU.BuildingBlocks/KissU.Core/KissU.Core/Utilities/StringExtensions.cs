using System.Text.RegularExpressions;

namespace KissU.Surging.CPlatform.Utilities
{
    /// <summary>
    /// 字符串扩展.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 确定指定的输入是否为ip.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the specified input is ip; otherwise, <c>false</c>.</returns>
        public static bool IsIP(this string input)
        {
            return input.IsMatch(
                @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:\d{2,5}\b");
        }

        /// <summary>
        /// 确定指定的操作是否匹配.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="op">The op.</param>
        /// <returns><c>true</c> if the specified op is match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(this string str, string op)
        {
            if (str.Equals(string.Empty) || str == null)
            {
                return false;
            }

            var re = new Regex(op, RegexOptions.IgnoreCase);
            return re.IsMatch(str);
        }
    }
}