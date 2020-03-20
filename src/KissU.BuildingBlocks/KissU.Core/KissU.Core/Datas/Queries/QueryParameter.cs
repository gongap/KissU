using KissU.Core.Domains.Repositories;

namespace KissU.Core.Datas.Queries
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryParameter : Pager, IQueryParameter
    {
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keyword { get; set; }
    }
}