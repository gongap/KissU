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
        /// ͨ��Id��ȡ�û�
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> Get(string id)
        {
            return _userAppService.GetAsync(id.ToGuid());
        }

        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="parameters">�������</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> Create(IdentityUserCreateDto parameters)
        {
            return _userAppService.CreateAsync(parameters);
        }

        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <param name="parameters">�������</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> Update(string id, IdentityUserUpdateDto parameters)
        {
            return _userAppService.UpdateAsync(id.ToGuid(), parameters);
        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <returns>Task.</returns>
        public virtual Task Delete(string id)
        {
            return _userAppService.DeleteAsync(id.ToGuid());
        }

        /// <summary>
        /// ��ȡ�û���ɫ
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <returns>Task&lt;ListResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        public virtual async Task<ListResult<IdentityRoleDto>> GetRoles(string id)
        {
            var result = await _userAppService.GetRolesAsync(id.ToGuid());
            return new ListResult<IdentityRoleDto>(result.Items);
        }

        /// <summary>
        /// ��ȡ�û��б�
        /// </summary>
        /// <param name="parameters">�������</param>
        /// <returns>Task&lt;PagedResult&lt;IdentityUserDto&gt;&gt;.</returns>
        public virtual async Task<PagedResult<IdentityUserDto>> GetList(GetIdentityUsersInput parameters)
        {
            var result = await _userAppService.GetListAsync(parameters);
            return new PagedResult<IdentityUserDto>(result.TotalCount, result.Items);
        }

        /// <summary>
        /// �����û���ɫ
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <param name="parameters">�������</param>
        /// <returns>Task.</returns>
        public virtual Task UpdateRoles(string id, IdentityUserUpdateRolesDto parameters)
        {
            return _userAppService.UpdateRolesAsync(id.ToGuid(), parameters);
        }

        /// <summary>
        /// ͨ���û��������û�
        /// </summary>
        /// <param name="username">�û���</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> FindByUsername(string username)
        {
            return _userAppService.FindByUsernameAsync(username);
        }

        /// <summary>
        /// ͨ����������û�
        /// </summary>
        /// <param name="email">����</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        public virtual Task<IdentityUserDto> FindByEmail(string email)
        {
            return _userAppService.FindByEmailAsync(email);
        }
    }
}