using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 权限服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IPermissionService : IServiceKey
    {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query);

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        Task SaveAsync(SavePermissionRequest request);
    }
}