using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Identity;
using Volo.Abp.Account;
using KissU.Modules.Account.Service.Contracts.Models;

namespace KissU.Modules.Account.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IAccountService : IServiceKey
    {
        /// <summary>
        /// 注册
        /// </summary>
        [HttpPost(true)]
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);

        /// <summary>
        /// 设置密码
        /// </summary>
        [HttpPost(true)]
        Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input);

        /// <summary>
        /// 重置密码
        /// </summary>
        [HttpPost(true)]
        Task ResetPasswordAsync(ResetPasswordDto input);

        /// <summary>
        /// 用戶授权
        /// </summary>
        /// <param name="requestData">请求参数</param>
        /// <returns>用户模型</returns>
        Task<IdentityUserDto> Authentication(AuthenticationRequestData requestData);
    }
}