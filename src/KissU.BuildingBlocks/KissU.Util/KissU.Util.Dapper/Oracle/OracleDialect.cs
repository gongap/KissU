﻿using KissU.Core;
using KissU.Core.Helpers;
using KissU.Util.Ddd.Domain.Datas.Sql.Builders.Core;

namespace KissU.Util.Dapper.Oracle
{
    /// <summary>
    /// Oracle方言
    /// </summary>
    public class OracleDialect : DialectBase
    {
        /// <summary>
        /// 起始转义标识符
        /// </summary>
        public override string OpeningIdentifier => "\"";

        /// <summary>
        /// 结束转义标识符
        /// </summary>
        public override string ClosingIdentifier => "\"";

        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>System.String.</returns>
        protected override string GetSafeName(string name)
        {
            return $"\"{name}\"";
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetPrefix()
        {
            return ":";
        }

        /// <summary>
        /// Select子句是否支持As关键字
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool SupportSelectAs()
        {
            return false;
        }

        /// <summary>
        /// 创建参数名
        /// </summary>
        /// <param name="paramIndex">参数索引</param>
        /// <returns>System.String.</returns>
        public override string GenerateName(int paramIndex)
        {
            return $"{GetPrefix()}p_{paramIndex}";
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <returns>System.String.</returns>
        public override string GetParamName(string paramName)
        {
            if (paramName.StartsWith(":"))
                return paramName.TrimStart(':');
            return paramName;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="paramValue">参数值</param>
        /// <returns>System.Object.</returns>
        public override object GetParamValue(object paramValue)
        {
            if (paramValue == null)
                return "";
            switch (paramValue.GetType().Name.ToLower())
            {
                case "boolean":
                    return Convert.ToBool(paramValue) ? 1 : 0;
                case "int16":
                case "int32":
                case "int64":
                case "single":
                case "double":
                case "decimal":
                    return paramValue.SafeString();
                default:
                    return $"{paramValue}";
            }
        }
    }
}