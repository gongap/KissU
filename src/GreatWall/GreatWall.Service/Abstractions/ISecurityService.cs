using System.Threading.Tasks;
using GreatWall.Results;
using GreatWall.Service.Dtos.Requests;
using Util.Applications;
using Util.Aspects;
using Util.Validations.Aspects;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 安全服务
    /// </summary>
    public interface ISecurityService : IService {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        Task<SignInResult> SignInAsync( [NotNull] [Valid] LoginRequest request );
        /// <summary>
        /// 退出登录
        /// </summary>
        Task SignOutAsync();
    }
}
