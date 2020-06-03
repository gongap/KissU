using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KissU.Helpers.Utilities
{
    /// <summary>
    /// 环境助手.
    /// </summary>
    public class EnvironmentHelper
    {
        /// <summary>
        /// 获取环境变量.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetEnvironmentVariable(string value)
        {
            var result = value;
            var param = GetParameters(result).FirstOrDefault();
            if (!string.IsNullOrEmpty(param))
            {
                var env = Environment.GetEnvironmentVariable(param);
                result = env;
                if (string.IsNullOrEmpty(env))
                {
                    var arrayData = value.Split('|');
                    result = arrayData.Length == 2 ? arrayData[1] : env;
                }
            }

            return result;
        }

        /// <summary>
        /// 获取bool环境变量.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool GetEnvironmentVariableAsBool(string name, bool defaultValue = false)
        {
            var str = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrEmpty(str))
            {
                return defaultValue;
            }

            switch (str.ToLowerInvariant())
            {
                case "true":
                case "1":
                case "yes":
                    return true;
                case "false":
                case "0":
                case "no":
                    return false;
                default:
                    return defaultValue;
            }
        }

        private static List<string> GetParameters(string text)
        {
            var matchVale = new List<string>();
            var Reg = @"(?<=\${)[^\${}]*(?=})";
            var key = string.Empty;
            foreach (Match m in System.Text.RegularExpressions.Regex.Matches(text, Reg))
            {
                matchVale.Add(m.Value);
            }

            return matchVale;
        }
    }
}