using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Results;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Service.Contracts
{
    /// <summary>
    /// 安全服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ISecurityService : IService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        Task<SignInResult> SignInAsync(LoginRequest request);

        /// <summary>
        /// 退出登录
        /// </summary>
        Task SignOutAsync();
    }
}