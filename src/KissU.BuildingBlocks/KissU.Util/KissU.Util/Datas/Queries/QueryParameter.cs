using KissU.Util.Domains.Repositories;
using KissU.Util.Ui.Attributes;

namespace KissU.Util.Datas.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    [Model( "queryParam" )]
    public class QueryParameter : Pager, IQueryParameter {
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keyword { get; set; }
    }
}
