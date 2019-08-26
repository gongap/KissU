using System.Threading.Tasks;
using KissU.IModuleServices.GreatWall.Abstractions;
using KissU.Modules.GreatWall.Data;
using KissU.IModuleServices.GreatWall.Dtos.Requests;
using KissU.IModuleServices.GreatWall.Results;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Abstractions;
using Util;
using Util.Applications;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 安全服务
    /// </summary>
    public class SecurityService : ServiceBase, ISecurityService
    {
        /// <summary>
        /// 初始化安全服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="signInManager">登录服务</param>
        /// <param name="userManager">用户服务</param>
        public SecurityService(IGreatWallUnitOfWork unitOfWork, ISignInManager signInManager, IUserManager userManager)
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
        public ISignInManager SignInManager { get; set; }
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
            var result = await SignInManager.SignInAsync(user, request.Password, request.Remember.SafeValue());
            await UnitOfWork.CommitAsync();
            return result;
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
        /// 退出登录
        /// </summary>
        public async Task SignOutAsync()
        {
            await SignInManager.SignOutAsync();
        }
    }
}
