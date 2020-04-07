using KissU.Util.Ddd.Domain.Datas.Sql.Builders.Core;

namespace KissU.Util.Dapper.SqlServer
{
    /// <summary>
    /// Sql Server方言
    /// </summary>
    public class SqlServerDialect : DialectBase
    {
        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>System.String.</returns>
        protected override string GetSafeName(string name)
        {
            return $"[{name}]";
        }
    }
}