using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.GreatWall.Service.Dtos.Requests;
using KissU.GreatWall.Service.Queries;
using Util.Applications;

namespace KissU.GreatWall.Service.Abstractions {
    /// <summary>
    /// 权限服务
    /// </summary>
    public interface IPermissionService : IService {
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