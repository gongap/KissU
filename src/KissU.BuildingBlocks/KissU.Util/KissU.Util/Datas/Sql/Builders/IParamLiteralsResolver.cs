﻿namespace KissU.Util.Datas.Sql.Builders
{
    /// <summary>
    /// 参数字面值解析器
    /// </summary>
    public interface IParamLiteralsResolver
    {
        /// <summary>
        /// 获取参数字面值
        /// </summary>
        /// <param name="value">参数值</param>
        /// <returns>System.String.</returns>
        string GetParamLiterals(object value);
    }
}
