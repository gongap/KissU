using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KissU.Core.CPlatform.Routing.Template
{
    /// <summary>
    /// 路由模式解析器.
    /// </summary>
    public class RoutePatternParser
    {
        /// <summary>
        /// 解析指定的路由模板.
        /// </summary>
        /// <param name="routeTemplet">The route templet.</param>
        /// <param name="service">The service.</param>
        /// <param name="method">The method.</param>
        /// <returns>System.String.</returns>
        public static string Parse(string routeTemplet, string service, string method)
        {
            StringBuilder result = new StringBuilder();
            var parameters = routeTemplet.Split(@"/");
            bool isAppendMethod=false;
            foreach (var parameter in parameters)
            {
                var param = GetParameters(parameter).FirstOrDefault();
                if (param == null)
                {
                    result.Append(parameter);
                }
                else if (service.EndsWith(param))
                {
                    result.Append(service.Substring(1, service.Length - param.Length - 1));
                }
                else if (param == "Method")
                {
                    result.Append(method);
                    isAppendMethod = true;
                }
                else
                {
                    if (!isAppendMethod)
                    {
                        result.AppendFormat("{0}/", method);
                    }

                    result.Append(parameter);
                    isAppendMethod = true;
                }

                result.Append("/");
            }

            result.Length = result.Length - 1;
            if (!isAppendMethod)
            {
                result.AppendFormat("/{0}", method);
            }

            return result.ToString().ToLower();
        }

        /// <summary>
        /// 解析指定的路由模板.
        /// </summary>
        /// <param name="routeTemplet">The route templet.</param>
        /// <param name="service">The service.</param>
        /// <returns>System.String.</returns>
        public static string Parse(string routeTemplet, string service)
        {
            StringBuilder result = new StringBuilder();
            var parameters = routeTemplet.Split(@"/");
            foreach (var parameter in parameters)
            {
                var param = GetParameters(parameter).FirstOrDefault();
                if (param == null)
                {
                    result.Append(parameter);
                }
                else if (service.EndsWith(param))
                {
                    result.Append(service.Substring(1, service.Length - param.Length - 1));
                }

                result.Append("/");
            }

            return result.ToString().TrimEnd('/').ToLower();
        }

        /// <summary>
        /// 获取参数.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> GetParameters(string text)
        {
            var matchVale = new List<string>();
            string reg = @"(?<={)[^{}]*(?=})";
            string key = string.Empty;
            foreach (Match m in Regex.Matches(text, reg))
            {
                matchVale.Add(m.Value);
            }

            return matchVale;
        }
    }
}