using KissU.Util.Datas.Sql.Builders.Core;

namespace KissU.Util.Datas.SqlServer.Dapper
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
        protected override string GetSafeName( string name )
        {
            return $"[{name}]";
        }
    }
}
