using System.Threading.Tasks;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Models;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// 角色服务
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("api/{Service}")]
    public interface IRoleService : IServiceKey
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns>Task&lt;ListResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        Task<ListResult<IdentityRoleDto>> GetAllList();

        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;PagedResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        [HttpPost(true)]
        Task<PagedResult<IdentityRoleDto>> GetList(GetIdentityRolesInput parameters);

        /// <summary>
        /// 通过Id获取角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;IdentityRoleDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<IdentityRoleDto> Get(string id);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityRoleDto&gt;.</returns>
        [HttpPost(true)]
        Task<IdentityRoleDto> Create(IdentityRoleCreateDto parameters);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityRoleDto&gt;.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task<IdentityRoleDto> Update(string id, IdentityRoleUpdateDto parameters);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task Delete(string id);
    }
}