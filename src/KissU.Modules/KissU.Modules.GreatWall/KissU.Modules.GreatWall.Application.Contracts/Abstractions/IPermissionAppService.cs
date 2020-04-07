using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Util.Ddd.Applications;

namespace KissU.Modules.GreatWall.Application.Contracts.Abstractions
{
    /// <summary>
    /// 权限服务
    /// </summary>
    public interface IPermissionAppService : IService
    {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query);

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns>Task.</returns>
        Task SaveAsync(SavePermissionRequest request);
    }
}