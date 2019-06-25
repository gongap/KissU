using System.Collections.Generic;

namespace KissU.Domain.Systems.Models
{
    /// <summary>
    /// Api资源
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// Api许可范围
        /// </summary>
        public List<ApiScope> ApiScopes { get; }
    }
}