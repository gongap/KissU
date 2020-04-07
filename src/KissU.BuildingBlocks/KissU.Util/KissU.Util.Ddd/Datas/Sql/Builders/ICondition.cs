namespace KissU.Util.Ddd.Domain.Datas.Sql.Builders
{
    /// <summary>
    /// Sql查询条件
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns>System.String.</returns>
        string GetCondition();
    }
}