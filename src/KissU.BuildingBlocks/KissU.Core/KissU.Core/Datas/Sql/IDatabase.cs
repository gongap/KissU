using System.Data;

namespace KissU.Core.Datas.Sql
{
    /// <summary>
    /// 数据库
    /// </summary>
    [Aspects.Ignore]
    public interface IDatabase
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>IDbConnection.</returns>
        IDbConnection GetConnection();
    }
}