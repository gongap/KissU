using System.ComponentModel.DataAnnotations;
using Util.Datas.Queries;

namespace KissU.Modules.IdentityServer.Service.Contracts.Queries
{
    /// <summary>
    /// 授权日志查询参数
    /// </summary>
    public class EventLogQuery : QueryParameter
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        [Display(Name = "事件类型")]
        public int? EventId { get; set; }
    }
}