using System.Threading.Tasks;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Results;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 安全服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ISecurityService : IServiceKey
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        /// <returns>Task&lt;SignInResult&gt;.</returns>
        Task<SignInResult> SignInAsync(LoginRequest request);

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns>Task.</returns>
        Task SignOutAsync();
    }
}