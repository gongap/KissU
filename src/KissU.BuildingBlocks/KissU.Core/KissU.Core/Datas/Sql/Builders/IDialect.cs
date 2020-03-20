namespace KissU.Core.Datas.Sql.Builders
{
    /// <summary>
    /// Sql方言
    /// </summary>
    public interface IDialect
    {
        /// <summary>
        /// 起始转义标识符
        /// </summary>
        string OpeningIdentifier { get; }

        /// <summary>
        /// 结束转义标识符
        /// </summary>
        string ClosingIdentifier { get; }

        /// <summary>
        /// 安全名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>System.String.</returns>
        string SafeName(string name);

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        /// <returns>System.String.</returns>
        string GetPrefix();

        /// <summary>
        /// Select子句是否支持As关键字
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SupportSelectAs();

        /// <summary>
        /// 创建参数名
        /// </summary>
        /// <param name="paramIndex">参数索引</param>
        /// <returns>System.String.</returns>
        string GenerateName(int paramIndex);

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <returns>System.String.</returns>
        string GetParamName(string paramName);

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="paramValue">参数值</param>
        /// <returns>System.Object.</returns>
        object GetParamValue(object paramValue);
    }
}