using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Extensions;
using GreatWall.Service.Dtos.Responses;
using Surging.Core.CPlatform.Transport.Implementation;
using Util;
using Util.Applications;
using Util.Helpers;
using Util.Security;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : ServiceBase, IMenuService {
        /// <summary>
        /// 初始化菜单服务
        /// </summary>
        /// <param name="roleRepository">角色仓储</param>
        /// <param name="moduleRepository">模块仓储</param>
        public MenuService( IRoleRepository roleRepository,IModuleRepository moduleRepository ) {
            RoleRepository = roleRepository;
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }
        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }

        /// <summary>
        /// 获取菜单
        /// </summary>
        public async Task<List<MenuResponse>> GetMenusAsync() {
            
            var userId = Session.UserId;
            if ( userId.IsEmpty() )
                return new List<MenuResponse>();
            var roleIds = await RoleRepository.GetRoleIdsAsync( userId.ToGuid() );
            var modules = await ModuleRepository.GetModulesAsync( Session.GetApplicationId(), roleIds );
            await AddMissingParents( modules );
            return modules.Select( t => t.ToMenuResponse() ).ToList();
        }

        /// <summary>
        /// 添加缺失的父节点列表
        /// </summary>
        private async Task AddMissingParents( List<Module> modules ) {
            var parentIds = modules.GetMissingParentIds<Module, Guid, Guid?>();
            var parents = await ModuleRepository.FindByIdsAsync( parentIds.Select( t => t.ToGuid() ) );
            modules.AddRange( parents.Where( t => t.Enabled ) );
        }
    }
}
