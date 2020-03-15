using KissU.Util.Datas.Sql.Matedatas;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.Samples
{
    /// <summary>
    /// 表数据库
    /// </summary>
    public class TestTableDatabase : ITableDatabase
    {
        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <param name="table">表</param>
        /// <returns>System.String.</returns>
        public string GetDatabase(string table)
        {
            return "test";
        }
    }
}