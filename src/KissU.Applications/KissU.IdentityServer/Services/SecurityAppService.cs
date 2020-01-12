using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos.Requests;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Domain;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using KissU.Modules.GreatWall.Domain.Services.Implements;
using KissU.Modules.GreatWall.Domain.Shared.Purposes;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 安全服务
    /// </summary>
    public class SecurityAppService : ServiceBase, ISecurityAppService
    {
        /// <summary>
        /// 初始化安全服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="signInManager">登录服务</param>
        /// <param name="userManager">用户服务</param>
        public SecurityAppService(IGreatWallUnitOfWork unitOfWork, IdentitySignInManager signInManager,
            IUserManager userManager)
        {
            UnitOfWork = unitOfWork;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 登录服务
        /// </summary>
        public IdentitySignInManager SignInManager { get; set; }

        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserManager UserManager { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        public async Task<SignInResult> SignInAsync(LoginRequest request)
        {
            var user = await GetUser(request);
            if (user == null)
                return new SignInResult(SignInState.Failed, null, GreatWallResource.InvalidAccountOrPassword);
            var signInResult = await SignInManager.PasswordSignInAsync(user, request.Password, request.Remember.SafeValue(), true);

            await UnitOfWork.CommitAsync();

            return GetSignInResult(user, signInResult);
        }

        /// <summary>
        /// 生成登录令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="application">应用程序</param>
        public async Task<string> GenerateSignInTokenAsync(string phone, string application = "")
        {
            return await UserManager.GenerateTokenAsync(phone, TokenPurpose.SignIn, application);
        }

        /// <summary>
        /// 令牌登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="token">令牌</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        /// <param name="application">应用程序</param>
        public async Task<SignInResult> TokenSignInAsync(string phone, string token, bool isPersistent,
            bool lockoutOnFailure, string application = "")
        {
            var user = await UserManager.FindByPhoneAsync(phone);
            if (user == null)
                return new SignInResult(SignInState.Failed, null, GreatWallResource.InvalidAccountOrPassword);
            var success = await UserManager.VerifyTokenAsync(user, TokenPurpose.SignIn, token, application);
            var signInResult =
                await SignInManager.TokenSignInAsync(user, success, isPersistent, lockoutOnFailure);
            return GetSignInResult(user, signInResult);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public async Task SignOutAsync()
        {
            await SignInManager.SignOutAsync();
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        private async Task<User> GetUser(LoginRequest request)
        {
            if (request.UserName.IsEmpty() == false)
                return await UserManager.FindByNameAsync(request.UserName);
            if (request.PhoneNumber.IsEmpty() == false)
                return await UserManager.FindByPhoneAsync(request.PhoneNumber);
            if (request.Email.IsEmpty() == false)
                return await UserManager.FindByEmailAsync(request.Email);
            if (request.Account.IsEmpty())
                return null;
            var user = await UserManager.FindByNameAsync(request.Account);
            if (user == null)
                user = await UserManager.FindByPhoneAsync(request.Account);
            if (user == null)
                user = await UserManager.FindByEmailAsync(request.Account);
            return user;
        }

        /// <summary>
        /// 获取登录结果
        /// </summary>
        private SignInResult GetSignInResult(User user, Microsoft.AspNetCore.Identity.SignInResult signInResult)
        {
            if (signInResult.IsNotAllowed)
                return new SignInResult(SignInState.Failed, null, GreatWallResource.UserIsDisabled);
            if (signInResult.IsLockedOut)
                return new SignInResult(SignInState.Failed, null, GreatWallResource.LoginFailLock);
            if (signInResult.Succeeded)
                return new SignInResult(SignInState.Succeeded, user.Id.SafeString());
            if (signInResult.RequiresTwoFactor)
                return new SignInResult(SignInState.TwoFactor, user.Id.SafeString());
            return new SignInResult(SignInState.Failed, null, GreatWallResource.InvalidAccountOrPassword);
        }
    }
}