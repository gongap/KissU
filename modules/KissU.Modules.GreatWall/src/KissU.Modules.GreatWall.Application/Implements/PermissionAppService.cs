using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Application.Contracts.Queries;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util.Ddd.Application;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 权限服务
    /// </summary>
    public class PermissionAppService : ServiceBase, IPermissionAppService
    {
        /// <summary>
        /// 初始化权限服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="permissionManager">权限服务</param>
        /// <param name="permissionRepository">权限仓储</param>
        public PermissionAppService(IGreatWallUnitOfWork unitOfWork, IPermissionManager permissionManager,
            IPermissionRepository permissionRepository)
        {
            UnitOfWork = unitOfWork;
            PermissionManager = permissionManager;
            PermissionRepository = permissionRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 权限服务
        /// </summary>
        public IPermissionManager PermissionManager { get; set; }

        /// <summary>
        /// 权限仓储
        /// </summary>
        public IPermissionRepository PermissionRepository { get; set; }

        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        /// <returns>Task&lt;List&lt;Guid&gt;&gt;.</returns>
        public async Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query)
        {
            return await PermissionRepository.GetResourceIdsAsync(query.ApplicationId.SafeValue(),
                query.RoleId.SafeValue(), query.IsDeny.SafeValue());
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        public async Task SaveAsync(SavePermissionRequest request)
        {
            await PermissionManager.SaveAsync(request.ApplicationId.SafeValue(), request.RoleId.SafeValue(),
                request.ResourceIds.ToGuidList(), request.IsDeny.SafeValue());
            await UnitOfWork.CommitAsync();
        }
    }
}