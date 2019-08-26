using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using Util;
using Util.Domains.Services;

namespace KissU.Modules.GreatWall.Domain.Services.Implements
{
    /// <summary>
    /// 权限服务
    /// </summary>
    public class PermissionManager : DomainServiceBase, IPermissionManager
    {
        /// <summary>
        /// 初始化权限服务
        /// </summary>
        /// <param name="permissionRepository">权限仓储</param>
        public PermissionManager(IPermissionRepository permissionRepository)
        {
            PermissionRepository = permissionRepository;
        }

        /// <summary>
        /// 权限仓储
        /// </summary>
        public IPermissionRepository PermissionRepository { get; set; }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleId">角色标识</param>
        /// <param name="resourceIds">资源标识列表</param>
        /// <param name="isDeny">是否拒绝</param>
        public async Task SaveAsync(Guid applicationId, Guid roleId, List<Guid> resourceIds, bool isDeny)
        {
            if (resourceIds == null)
                return;
            var oldResourceIds = await PermissionRepository.GetResourceIdsAsync(applicationId, roleId, isDeny);
            var result = resourceIds.Compare(oldResourceIds);
            await PermissionRepository.AddAsync(ToPermissions(roleId, result.CreateList, isDeny));
            await PermissionRepository.RemoveAsync(roleId, result.DeleteList);
        }

        /// <summary>
        /// 转换为权限实体列表
        /// </summary>
        private List<Permission> ToPermissions(Guid roleId, List<Guid> resourceIds, bool isDeny)
        {
            return resourceIds.Select(resourceId => ToPermission(roleId, resourceId, isDeny)).ToList();
        }

        /// <summary>
        /// 转换为权限实体
        /// </summary>
        private Permission ToPermission(Guid roleId, Guid resourceId, bool isDeny)
        {
            var result = new Permission
            {
                RoleId = roleId,
                ResourceId = resourceId,
                IsDeny = isDeny
            };
            result.Init();
            return result;
        }
    }
}
