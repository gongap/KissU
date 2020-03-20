using System.Threading.Tasks;
using KissU.Core.Applications;
using KissU.Core.Aspects;
using KissU.Core.Validations.Aspects;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Results;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions
{
    /// <summary>
    /// 安全服务
    /// </summary>
    public interface ISecurityAppService : IService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        /// <returns>Task&lt;SignInResult&gt;.</returns>
        Task<SignInResult> SignInAsync([NotNull] [Valid] LoginRequest request);

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns>Task.</returns>
        Task SignOutAsync();
    }
}