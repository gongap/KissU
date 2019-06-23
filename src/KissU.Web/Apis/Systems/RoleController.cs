using Util.Ui.Controllers;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Web.Apis.Systems
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : TreeControllerBase<RoleDto, RoleQuery>
    {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleController(IRoleService service) : base(service)
        {
            RoleService = service;
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleService RoleService { get; }
    }

    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleTableController : TreeTableControllerBase<RoleDto, RoleQuery>
    {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleTableController(IRoleService service) : base(service)
        {
            RoleService = service;
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleService RoleService { get; }
    }
}