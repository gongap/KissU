using System.Threading.Tasks;
using KissU.Extensions;
using KissU.Models;
using KissU.Modules.Common.Service.Contracts;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Implements
{
    /// <summary>
    /// Class RoleService.
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IRoleService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IRoleService" />
    public class RoleService : ProxyServiceBase, IRoleService
    {
        private readonly IIdentityRoleAppService _appService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="appService">The application service.</param>
        public RoleService(IIdentityRoleAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns>Task&lt;ListResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        public virtual async Task<ListResult<IdentityRoleDto>> GetAllList()
        {
            await base.GetService<IManagerService>().SayHello("gongap");
            var result = await _appService.GetAllListAsync();
            return new ListResult<IdentityRoleDto>(result.Items);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;PagedResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        public virtual async Task<PagedResult<IdentityRoleDto>> GetList(GetIdentityRolesInput input)
        {
            var result = await _appService.GetListAsync(input);
            return new PagedResult<IdentityRoleDto>(result.TotalCount, result.Items);
        }

        /// <summary>
        /// 通过Id获取角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;IdentityRoleDto&gt;.</returns>
        public virtual Task<IdentityRoleDto> Get(string id)
        {
            return _appService.GetAsync(id.ToGuid());
        }

        /// <summary>
        /// Creates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;IdentityRoleDto&gt;.</returns>
        public virtual Task<IdentityRoleDto> Create(IdentityRoleCreateDto input)
        {
            return _appService.CreateAsync(input);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;IdentityRoleDto&gt;.</returns>
        public virtual Task<IdentityRoleDto> Update(string id, IdentityRoleUpdateDto input)
        {
            return _appService.UpdateAsync(id.ToGuid(), input);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task.</returns>
        public virtual Task Delete(string id)
        {
            return _appService.DeleteAsync(id.ToGuid());
        }
    }
}