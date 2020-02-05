using System.Collections.Generic;
using KissU.Util.Datas.Queries;

namespace KissU.Util.Datas.Sql.Builders
{
    /// <summary>
    /// 参数管理器
    /// </summary>
    public interface IParameterManager
    {
        /// <summary>
        /// 创建参数名
        /// </summary>
        /// <returns>System.String.</returns>
        string GenerateName();

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <returns>IReadOnlyDictionary&lt;System.String, System.Object&gt;.</returns>
        IReadOnlyDictionary<string, object> GetParams();

        /// <summary>
        /// 添加参数,如果参数已存在则替换
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="operator">运算符</param>
        void Add(string name, object value, Operator? @operator = null);

        /// <summary>
        /// 复制副本
        /// </summary>
        /// <returns>IParameterManager.</returns>
        IParameterManager Clone();

        /// <summary>
        /// 清空参数
        /// </summary>
        void Clear();
    }
}
