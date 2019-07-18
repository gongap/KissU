using System.Threading.Tasks;
using GreatWall.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GreatWall.Domain.Services.Implements {
    /// <summary>
    /// Identity登录服务
    /// </summary>
    public class IdentitySignInManager : SignInManager<User> {
        /// <summary>
        /// 初始化Identity登录服务
        /// </summary>
        /// <param name="userManager">Identity用户服务</param>
        /// <param name="contextAccessor">HttpContext访问器</param>
        /// <param name="claimsFactory">用户声明工厂</param>
        /// <param name="optionsAccessor">Identity配置</param>
        /// <param name="logger">日志</param>
        /// <param name="schemes">认证架构提供程序</param>
        public IdentitySignInManager( UserManager<User> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes )
                : base( userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes ) {
        }

        /// <summary>
        /// 是否允许登录
        /// </summary>
        /// <param name="user">用户</param>
        public override async Task<bool> CanSignInAsync( User user ) {
            if( user.Enabled == false )
                return false;
            return await base.CanSignInAsync( user );
        }
    }
}
