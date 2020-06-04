using System;
using System.Collections.Generic;
using System.Text;
using KissU.Extensions;

namespace KissU.Helpers
{
    /// <summary>
    /// 字符串操作 - 字符串生成器
    /// </summary>
    public partial class StringHelper
    {
        /// <summary>
        /// 初始化字符串操作
        /// </summary>
        public StringHelper()
        {
            Builder = new StringBuilder();
        }

        /// <summary>
        /// 字符串生成器
        /// </summary>
        private StringBuilder Builder { get; set; }

        /// <summary>
        /// 字符串长度
        /// </summary>
        public int Length => Builder.Length;

        /// <summary>
        /// 空字符串
        /// </summary>
        public string Empty => string.Empty;

        /// <summary>
        /// 追加内容
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="value">值</param>
        /// <returns>String.</returns>
        public StringHelper Append<T>(T value)
        {
            Builder.Append(value);
            return this;
        }

        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">参数</param>
        /// <returns>String.</returns>
        public StringHelper Append(string value, params object[] args)
        {
            if (args == null)
                args = new object[] {string.Empty};
            if (args.Length == 0)
                Builder.Append(value);
            else
                Builder.AppendFormat(value, args);
            return this;
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        /// <returns>String.</returns>
        public StringHelper AppendLine()
        {
            Builder.AppendLine();
            return this;
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="value">值</param>
        /// <returns>String.</returns>
        public StringHelper AppendLine<T>(T value)
        {
            Append(value);
            Builder.AppendLine();
            return this;
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">参数</param>
        /// <returns>String.</returns>
        public StringHelper AppendLine(string value, params object[] args)
        {
            Append(value, args);
            Builder.AppendLine();
            return this;
        }

        /// <summary>
        /// 替换内容
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>String.</returns>
        public StringHelper Replace(string value)
        {
            Builder.Clear();
            Builder.Append(value);
            return this;
        }

        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="end">末尾字符串</param>
        /// <returns>String.</returns>
        public StringHelper RemoveEnd(string end)
        {
            var result = Builder.ToString();
            if (!result.EndsWith(end))
                return this;
            Builder = new StringBuilder(result.TrimEnd(end.ToCharArray()));
            return this;
        }

        /// <summary>
        /// 清空字符串
        /// </summary>
        /// <returns>String.</returns>
        public StringHelper Clear()
        {
            Builder = Builder.Clear();
            return this;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Builder.ToString();
        }

        #region Join(将集合连接为带分隔符的字符串)

        /// <summary>
        /// 将集合连接为带分隔符的字符串
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        /// <returns>System.String.</returns>
        public static string Join<T>(IEnumerable<T> list, string quotes = "", string separator = ",")
        {
            if (list == null)
                return string.Empty;
            var result = new StringBuilder();
            foreach (var each in list)
                result.AppendFormat("{0}{1}{0}{2}", quotes, each, separator);
            if (separator == "")
                return result.ToString();
            return result.ToString().TrimEnd(separator.ToCharArray());
        }

        #endregion

        #region FirstLowerCase(首字母小写)

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>System.String.</returns>
        public static string FirstLowerCase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            return $"{value.Substring(0, 1).ToLower()}{value.Substring(1)}";
        }

        #endregion

        #region FirstUpperCase(首字母大写)

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>System.String.</returns>
        public static string FirstUpperCase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            return $"{value.Substring(0, 1).ToUpper()}{value.Substring(1)}";
        }

        #endregion

        #region RemoveEnd(移除末尾字符串)

        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="removeValue">要移除的值</param>
        /// <returns>System.String.</returns>
        public static string RemoveEnd(string value, string removeValue)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            if (string.IsNullOrWhiteSpace(removeValue))
                return value.SafeString();
            if (value.ToLower().EndsWith(removeValue.ToLower()))
                return value.Remove(value.Length - removeValue.Length, removeValue.Length);
            return value;
        }

        #endregion

        #region SplitWordGroup(分隔词组)

        /// <summary>
        /// 分隔词组
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="separator">分隔符，默认使用"-"分隔</param>
        /// <returns>System.String.</returns>
        public static string SplitWordGroup(string value, char separator = '-')
        {
            var pattern = @"([A-Z])(?=[a-z])|(?<=[a-z])([A-Z]|[0-9]+)";
            return string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : System.Text.RegularExpressions.Regex.Replace(value, pattern, $"{separator}$1$2").TrimStart(separator)
                    .ToLower();
        }

        #endregion

        #region PinYin(获取汉字的拼音简码)

        /// <summary>
        /// 获取汉字的拼音简码，即首字母缩写,范例：中国,返回zg
        /// </summary>
        /// <param name="chineseText">汉字文本,范例： 中国</param>
        /// <returns>System.String.</returns>
        public static string PinYin(string chineseText)
        {
            if (string.IsNullOrWhiteSpace(chineseText))
                return string.Empty;
            var result = new StringBuilder();
            foreach (var text in chineseText)
                result.AppendFormat("{0}", ResolvePinYin(text));
            return result.ToString().ToLower();
        }

        /// <summary>
        /// 解析单个汉字的拼音简码
        /// </summary>
        private static string ResolvePinYin(char text)
        {
            var charBytes = Encoding.UTF8.GetBytes(text.ToString());
            if (charBytes[0] <= 127)
                return text.ToString();
            var unicode = (ushort)(charBytes[0] * 256 + charBytes[1]);
            var pinYin = ResolveByCode(unicode);
            if (!string.IsNullOrWhiteSpace(pinYin))
                return pinYin;
            return ResolveByConst(text.ToString());
        }

        /// <summary>
        /// 使用字符编码方式获取拼音简码
        /// </summary>
        private static string ResolveByCode(ushort unicode)
        {
            if (unicode >= '\uB0A1' && unicode <= '\uB0C4')
                return "A";
            if (unicode >= '\uB0C5' && unicode <= '\uB2C0' && unicode != 45464)
                return "B";
            if (unicode >= '\uB2C1' && unicode <= '\uB4ED')
                return "C";
            if (unicode >= '\uB4EE' && unicode <= '\uB6E9')
                return "D";
            if (unicode >= '\uB6EA' && unicode <= '\uB7A1')
                return "E";
            if (unicode >= '\uB7A2' && unicode <= '\uB8C0')
                return "F";
            if (unicode >= '\uB8C1' && unicode <= '\uB9FD')
                return "G";
            if (unicode >= '\uB9FE' && unicode <= '\uBBF6')
                return "H";
            if (unicode >= '\uBBF7' && unicode <= '\uBFA5')
                return "J";
            if (unicode >= '\uBFA6' && unicode <= '\uC0AB')
                return "K";
            if (unicode >= '\uC0AC' && unicode <= '\uC2E7')
                return "L";
            if (unicode >= '\uC2E8' && unicode <= '\uC4C2')
                return "M";
            if (unicode >= '\uC4C3' && unicode <= '\uC5B5')
                return "N";
            if (unicode >= '\uC5B6' && unicode <= '\uC5BD')
                return "O";
            if (unicode >= '\uC5BE' && unicode <= '\uC6D9')
                return "P";
            if (unicode >= '\uC6DA' && unicode <= '\uC8BA')
                return "Q";
            if (unicode >= '\uC8BB' && unicode <= '\uC8F5')
                return "R";
            if (unicode >= '\uC8F6' && unicode <= '\uCBF9')
                return "S";
            if (unicode >= '\uCBFA' && unicode <= '\uCDD9')
                return "T";
            if (unicode >= '\uCDDA' && unicode <= '\uCEF3')
                return "W";
            if (unicode >= '\uCEF4' && unicode <= '\uD188')
                return "X";
            if (unicode >= '\uD1B9' && unicode <= '\uD4D0')
                return "Y";
            if (unicode >= '\uD4D1' && unicode <= '\uD7F9')
                return "Z";
            return string.Empty;
        }

        /// <summary>
        /// 通过拼音简码常量获取
        /// </summary>
        private static string ResolveByConst(string text)
        {
            var index = ConstHelper.ChinesePinYin.IndexOf(text, StringComparison.Ordinal);
            if (index < 0)
                return string.Empty;
            return ConstHelper.ChinesePinYin.Substring(index + 1, 1);
        }

        #endregion
    }
}