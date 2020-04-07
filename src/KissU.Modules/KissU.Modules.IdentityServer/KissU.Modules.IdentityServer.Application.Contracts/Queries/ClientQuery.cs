using System.ComponentModel.DataAnnotations;
using KissU.Util.Ddd.Datas.Queries;

namespace KissU.Modules.IdentityServer.Application.Contracts.Queries
{
    /// <summary>
    /// 应用程序查询实体
    /// </summary>
    public class ClientQuery : QueryParameter
    {
        /// <summary>
        /// 启用状态
        /// </summary>
        [Display(Name = "启用状态")]
        public bool? Enabled { get; set; }
    }
}