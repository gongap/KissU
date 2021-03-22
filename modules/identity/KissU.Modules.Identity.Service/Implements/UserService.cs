using System.Threading.Tasks;
using KissU.Extensions;
using KissU.Models;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Implements
{
    /// <summary>
    /// Class UserService.
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IUserService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IUserService" />
    public class UserService : ProxyServiceBase, IUserService
    {
        private readonly IIdentityUserAppService _userAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userAppService">The user application service.</param>
        public UserService(IIdentityUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// 通过Id获取用户
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> Get(string id)
        {
            return _userAppService.GetAsync(id.ToGuid());
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> Create(IdentityUserCreateDto parameters)
        {
            return _userAppService.CreateAsync(parameters);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> Update(string id, IdentityUserUpdateDto parameters)
        {
            return _userAppService.UpdateAsync(id.ToGuid(), parameters);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task.</returns>
        public virtual Task Delete(string id)
        {
            return _userAppService.DeleteAsync(id.ToGuid());
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;ListResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        public virtual async Task<ListResult<IdentityRoleDto>> GetRoles(string id)
        {
            var result = await _userAppService.GetRolesAsync(id.ToGuid());
            return new ListResult<IdentityRoleDto>(result.Items);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;PagedResult&lt;IdentityUserDto&gt;&gt;.</returns>
        public virtual async Task<PagedResult<IdentityUserDto>> GetList(GetIdentityUsersInput parameters)
        {
            var result = await _userAppService.GetListAsync(parameters);
            return new PagedResult<IdentityUserDto>(result.TotalCount, result.Items);
        }

        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        public virtual Task UpdateRoles(string id, IdentityUserUpdateRolesDto parameters)
        {
            return _userAppService.UpdateRolesAsync(id.ToGuid(), parameters);
        }

        /// <summary>
        /// 通过用户名查找用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> FindByUsername(string username)
        {
            return _userAppService.FindByUsernameAsync(username);
        }

        /// <summary>
        /// 通过邮箱查找用户
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> FindByEmail(string email)
        {
            return _userAppService.FindByEmailAsync(email);
        }
    }
}