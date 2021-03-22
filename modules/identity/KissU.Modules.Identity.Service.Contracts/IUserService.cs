using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Models;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// 用户服务
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IServiceKey
    {
        /// <summary>
        /// 通过Id获取用户
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> Get(string id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;PagedResult&lt;IdentityUserDto&gt;&gt;.</returns>
        [HttpPost(true)]
        Task<PagedResult<IdentityUserDto>> GetList(GetIdentityUsersInput parameters);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpPost(true)]
        Task<IdentityUserDto> Create(IdentityUserCreateDto parameters);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> Update(string id, IdentityUserUpdateDto parameters);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task Delete(string id);

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;ListResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<ListResult<IdentityRoleDto>> GetRoles(string id);

        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task UpdateRoles(string id, IdentityUserUpdateRolesDto parameters);

        /// <summary>
        /// 通过用户名查找用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{userName}")]
        Task<IdentityUserDto> FindByUsername(string username);

        /// <summary>
        /// 通过邮箱查找用户
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{email}")]
        Task<IdentityUserDto> FindByEmail(string email);
    }
}