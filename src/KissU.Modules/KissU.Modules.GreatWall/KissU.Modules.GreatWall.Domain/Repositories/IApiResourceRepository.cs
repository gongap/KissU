using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories {
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public interface IApiResourceRepository : ICompactRepository<ApiResource> {
        /// <summary>
        /// 是否允许创建资源
        /// </summary>
        /// <param name="resource">资源</param>
        Task<bool> CanCreateAsync( ApiResource resource );
        /// <summary>
        /// 是否允许修改资源
        /// </summary>
        /// <param name="resource">资源</param>
        Task<bool> CanUpdateAsync( ApiResource resource );
        /// <summary>
        /// 获取已启用的Api资源列表
        /// </summary>
        Task<List<ApiResource>> GetEnabledResources();
    }
}