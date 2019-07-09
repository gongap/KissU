using System.Collections.Generic;
namespace JobScheduler.Domain.Systems.Models
{
    /// <summary>
    /// Api资源
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// 许可范围
        /// </summary>
        public List<ApiScope> ApiScopes { get; private set; }

        /// <summary>
        /// 添加许可范围
        /// </summary>
        /// <param name="apiScope"></param>
        public void AddApiScope(ApiScope apiScope)
        {
            if (apiScope == null)
            {
                return;
            }
            apiScope.Init();
            apiScope.ApiId = this.Id;
            ApiScopes.Add(apiScope);
        }
    }
}