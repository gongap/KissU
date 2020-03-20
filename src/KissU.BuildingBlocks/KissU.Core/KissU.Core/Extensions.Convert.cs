using System;
using System.Collections.Generic;
using System.Linq;
using Convert = KissU.Core.Helpers.Convert;

namespace KissU.Core
{
    /// <summary>
    /// 系统扩展 - 类型转换
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>System.String.</returns>
        public static string SafeString(this object input)
        {
            return input?.ToString().Trim() ?? string.Empty;
        }

        /// <summary>
        /// 转换为bool
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBool(this string obj)
        {
            return Convert.ToBool(obj);
        }

        /// <summary>
        /// 转换为可空bool
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool? ToBoolOrNull(this string obj)
        {
            return Convert.ToBoolOrNull(obj);
        }

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this string obj)
        {
            return Convert.ToInt(obj);
        }

        /// <summary>
        /// 转换为可空int
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public static int? ToIntOrNull(this string obj)
        {
            return Convert.ToIntOrNull(obj);
        }

        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Int64.</returns>
        public static long ToLong(this string obj)
        {
            return Convert.ToLong(obj);
        }

        /// <summary>
        /// 转换为可空long
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Nullable&lt;System.Int64&gt;.</returns>
        public static long? ToLongOrNull(this string obj)
        {
            return Convert.ToLongOrNull(obj);
        }

        /// <summary>
        /// 转换为double
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Double.</returns>
        public static double ToDouble(this string obj)
        {
            return Convert.ToDouble(obj);
        }

        /// <summary>
        /// 转换为可空double
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Nullable&lt;System.Double&gt;.</returns>
        public static double? ToDoubleOrNull(this string obj)
        {
            return Convert.ToDoubleOrNull(obj);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Decimal.</returns>
        public static decimal ToDecimal(this string obj)
        {
            return Convert.ToDecimal(obj);
        }

        /// <summary>
        /// 转换为可空decimal
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
        public static decimal? ToDecimalOrNull(this string obj)
        {
            return Convert.ToDecimalOrNull(obj);
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDate(this string obj)
        {
            return Convert.ToDate(obj);
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? ToDateOrNull(this string obj)
        {
            return Convert.ToDateOrNull(obj);
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>Guid.</returns>
        public static Guid ToGuid(this string obj)
        {
            return Convert.ToGuid(obj);
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns>System.Nullable&lt;Guid&gt;.</returns>
        public static Guid? ToGuidOrNull(this string obj)
        {
            return Convert.ToGuidOrNull(obj);
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="obj">数据,范例: "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A"</param>
        /// <returns>List&lt;Guid&gt;.</returns>
        public static List<Guid> ToGuidList(this string obj)
        {
            return Convert.ToGuidList(obj);
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="obj">字符串集合</param>
        /// <returns>List&lt;Guid&gt;.</returns>
        public static List<Guid> ToGuidList(this IList<string> obj)
        {
            if (obj == null)
                return new List<Guid>();
            return obj.Select(t => t.ToGuid()).ToList();
        }
    }
}