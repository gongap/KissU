using System.Threading.Tasks;
using GreatWall.Domain.Models;
using GreatWall.Domain.Services.Abstractions;
using GreatWall.Results;
using Util;
using Util.Exceptions;

namespace GreatWall.Domain.Services.Implements {
    /// <summary>
    /// 登录服务
    /// </summary>
    public class SignInManager : ISignInManager {
        /// <summary>
        /// 初始化登录服务
        /// </summary>
        /// <param name="signInManager">Identity登录服务</param>
        /// <param name="userManager">用户服务</param>
        public SignInManager( IdentitySignInManager signInManager, IUserManager userManager ) {
            IdentitySignInManager = signInManager;
            UserManager = userManager;
        }

        /// <summary>
        /// Identity登录服务
        /// </summary>
        protected IdentitySignInManager IdentitySignInManager { get; }
        /// <summary>
        /// 用户服务
        /// </summary>
        protected IUserManager UserManager { get; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        public async Task<SignInResult> SignInAsync( User user, string password, bool isPersistent,bool lockoutOnFailure ) {
            if( user == null )
                throw new Warning( GreatWallResource.InvalidAccountOrPassword );
            var result = await PasswordSignIn( user, password, isPersistent, lockoutOnFailure );
            if( result.State == SignInState.Failed )
                throw new Warning( GreatWallResource.InvalidAccountOrPassword );
            return result;
        }

        /// <summary>
        /// 密码登录
        /// </summary>
        private async Task<SignInResult> PasswordSignIn( User user, string password, bool isPersistent, bool lockoutOnFailure ) {
            var signInResult = await IdentitySignInManager.PasswordSignInAsync( user, password, isPersistent, lockoutOnFailure );
            if( signInResult.IsNotAllowed )
                throw new Warning( GreatWallResource.UserIsDisabled );
            if( signInResult.IsLockedOut )
                throw new Warning( GreatWallResource.LoginFailLock );
            if( signInResult.Succeeded )
                return new SignInResult( SignInState.Succeeded,user.Id.SafeString() );
            if( signInResult.RequiresTwoFactor )
                return new SignInResult( SignInState.TwoFactor, user.Id.SafeString() );
            return new SignInResult( SignInState.Failed, string.Empty );
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public async Task SignOutAsync() {
            await IdentitySignInManager.SignOutAsync();
        }
    }
}
