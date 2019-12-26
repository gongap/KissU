using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Domain.Repositories {
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public interface IIdentityResourceRepository : ICompactRepository<IdentityResource> {
        /// <summary>
        /// 是否允许创建身份资源
        /// </summary>
        /// <param name="identityResource">身份资源</param>
        Task<bool> CanCreateAsync( IdentityResource identityResource );
        /// <summary>
        /// 是否允许修改身份资源
        /// </summary>
        /// <param name="identityResource">身份资源</param>
        Task<bool> CanUpdateAsync( IdentityResource identityResource );
        /// <summary>
        /// 获取已启用的身份资源列表
        /// </summary>
        Task<List<IdentityResource>> GetEnabledResources();
    }
}