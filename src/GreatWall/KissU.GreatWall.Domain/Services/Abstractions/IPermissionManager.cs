using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains.Services;

namespace KissU.GreatWall.Domain.Services.Abstractions {
    /// <summary>
    /// 权限服务
    /// </summary>
    public interface IPermissionManager : IDomainService {
        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleId">角色标识</param>
        /// <param name="resourceIds">资源标识列表</param>
        /// <param name="isDeny">是否拒绝</param>
        Task SaveAsync( Guid applicationId, Guid roleId, List<Guid> resourceIds, bool isDeny );
    }
}
