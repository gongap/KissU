using System.Collections.Generic;
namespace KissU.Domain.Systems.Models
{
    /// <summary>
    /// Api资源
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// 许可范围
        /// </summary>
        public IEnumerable<ApiScope> ApiScopes { get; set; }
    }
}