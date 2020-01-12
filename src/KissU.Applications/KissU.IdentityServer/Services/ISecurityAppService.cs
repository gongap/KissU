using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Util.Applications;
using KissU.Util.Aspects;
using KissU.Util.Validations.Aspects;

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
        Task<SignInResult> SignInAsync([NotNull] [Valid] LoginRequest request);

        /// <summary>
        /// 生成登录令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="application">应用程序</param>
        Task<string> GenerateSignInTokenAsync(string phone, string application = "");

        /// <summary>
        /// 令牌登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="token">令牌</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        /// <param name="application">应用程序</param>
        Task<SignInResult> TokenSignInAsync(string phone, string token, bool isPersistent, bool lockoutOnFailure,
            string application = "");

        /// <summary>
        /// 退出登录
        /// </summary>
        Task SignOutAsync();
    }
}