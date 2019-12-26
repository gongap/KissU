using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions {
    /// <summary>
    /// 权限服务
    /// </summary>
    public interface IPermissionAppService : IService {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        Task<List<Guid>> GetResourceIdsAsync( PermissionQuery query );
        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        Task SaveAsync( SavePermissionRequest request );
    }
}