using System.Data;

namespace KissU.Util.Datas.Sql
{
    /// <summary>
    /// 数据库
    /// </summary>
    [Util.Aspects.Ignore]
    public interface IDatabase
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        IDbConnection GetConnection();
    }
}
