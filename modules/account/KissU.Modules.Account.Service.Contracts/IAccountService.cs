using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts.Models;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 账号服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IAccountService : IServiceKey
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;UserData&gt;.</returns>
        // [Authorization(AuthType = AuthorizationType.AppSecret)]
        [HttpPost(true)]
        Task<UserData> Login(LoginDto parameters);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;IdentityUserDto&gt;.</returns>
        // [Authorization(AuthType = AuthorizationType.AppSecret)]
        [HttpPost(true)]
        Task<IdentityUserDto> Register(RegisterDto parameters);

        /// <summary>
        /// 发送密码重置码
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        // [Authorization(AuthType = AuthorizationType.AppSecret)]
        [HttpPost(true)]
        Task SendPasswordResetCode(SendPasswordResetCodeDto parameters);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        // [Authorization(AuthType = AuthorizationType.AppSecret)]
        [HttpPost(true)]
        Task ResetPassword(ResetPasswordDto parameters);
    }
}