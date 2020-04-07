using System.Data;

namespace KissU.Util.Ddd.Data.Sql
{
    /// <summary>
    /// 数据库
    /// </summary>
    [Core.Aspects.Ignore]
    public interface IDatabase
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>IDbConnection.</returns>
        IDbConnection GetConnection();
    }
}