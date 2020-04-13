using System.IO;
using System.Text;
using System.Web;

namespace KissU.Core.Helpers
{
    /// <summary>
    /// Url操作
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// 合并Url
        /// </summary>
        /// <param name="urls">url片断，范例：Url.Combine( "http://a.com","b" ),返回 "http://a.com/b"</param>
        /// <returns>System.String.</returns>
        public static string Combine(params string[] urls)
        {
            return Path.Combine(urls).Replace(@"\", "/");
        }

        /// <summary>
        /// 连接Url，范例：Url.Join( "http://a.com","b=1" ),返回 "http://a.com?b=1"
        /// </summary>
        /// <param name="url">Url，范例：http://a.com</param>
        /// <param name="param">参数，范例：b=1</param>
        /// <returns>System.String.</returns>
        public static string Join(string url, string param)
        {
            return $"{GetUrl(url)}{param}";
        }

        /// <summary>
        /// 获取Url
        /// </summary>
        private static string GetUrl(string url)
        {
            if (!url.Contains("?"))
                return $"{url}?";
            if (url.EndsWith("?"))
                return url;
            if (url.EndsWith("&"))
                return url;
            return $"{url}&";
        }


        #region UrlEncode(Url编码)

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        /// <returns>System.String.</returns>
        public static string Encode(string url, bool isUpper = false)
        {
            return Encode(url, Encoding.UTF8, isUpper);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        /// <returns>System.String.</returns>
        public static string Encode(string url, string encoding, bool isUpper = false)
        {
            encoding = string.IsNullOrWhiteSpace(encoding) ? "UTF-8" : encoding;
            return Encode(url, Encoding.GetEncoding(encoding), isUpper);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        /// <returns>System.String.</returns>
        public static string Encode(string url, Encoding encoding, bool isUpper = false)
        {
            var result = HttpUtility.UrlEncode(url, encoding);
            if (isUpper == false)
                return result;
            return GetUpperEncode(result);
        }

        /// <summary>
        /// 获取大写编码字符串
        /// </summary>
        private static string GetUpperEncode(string encode)
        {
            var result = new StringBuilder();
            var index = int.MinValue;
            for (var i = 0; i < encode.Length; i++)
            {
                var character = encode[i].ToString();
                if (character == "%")
                    index = i;
                if (i - index == 1 || i - index == 2)
                    character = character.ToUpper();
                result.Append(character);
            }

            return result.ToString();
        }

        #endregion

        #region UrlDecode(Url解码)

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>System.String.</returns>
        public static string Decode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>System.String.</returns>
        public static string Decode(string url, Encoding encoding)
        {
            return HttpUtility.UrlDecode(url, encoding);
        }

        #endregion
    }
}