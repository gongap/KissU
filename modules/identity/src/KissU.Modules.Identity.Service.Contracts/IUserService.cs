using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Models;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// �û�����
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IServiceKey
    {
        /// <summary>
        /// ͨ��Id��ȡ�û�
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> Get(string id);

        /// <summary>
        /// ��ȡ�û��б�
        /// </summary>
        /// <param name="parameters">�������</param>
        /// <returns>Task&lt;PagedResult&lt;IdentityUserDto&gt;&gt;.</returns>
        [HttpPost(true)]
        Task<PagedResult<IdentityUserDto>> GetList(GetIdentityUsersInput parameters);

        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="parameters">�������</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpPost(true)]
        Task<IdentityUserDto> Create(IdentityUserCreateDto parameters);

        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <param name="parameters">�������</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task<IdentityUserDto> Update(string id, IdentityUserUpdateDto parameters);

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task Delete(string id);

        /// <summary>
        /// ��ȡ�û���ɫ
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <returns>Task&lt;ListResult&lt;IdentityRoleDto&gt;&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<ListResult<IdentityRoleDto>> GetRoles(string id);

        /// <summary>
        /// �����û���ɫ
        /// </summary>
        /// <param name="id">Id��ʶ</param>
        /// <param name="parameters">�������</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [ServiceRoute("{id}")]
        Task UpdateRoles(string id, IdentityUserUpdateRolesDto parameters);

        /// <summary>
        /// ͨ���û��������û�
        /// </summary>
        /// <param name="username">�û���</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{userName}")]
        Task<IdentityUserDto> FindByUsername(string username);

        /// <summary>
        /// ͨ����������û�
        /// </summary>
        /// <param name="email">����</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{email}")]
        Task<IdentityUserDto> FindByEmail(string email);
    }
}