using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using KissU.IModuleServices.GreatWall.Abstractions;
using KissU.IModuleServices.GreatWall.Dtos;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Implements;
using Microsoft.AspNetCore.Identity;
using Util;
using Claim = System.Security.Claims.Claim;
using ClaimTypes = Util.Security.Claims.ClaimTypes;

namespace KissU.Authentication.Authentications
{
    /// <summary>
    /// 用户身份配置服务
    /// </summary>
    public class ProfileService : ProfileService<User>
    {
        /// <summary>
        /// 用户声明工厂
        /// </summary>
        private readonly IUserClaimsPrincipalFactory<User> _claimsFactory;

        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly IdentityUserManager _userManager;

        /// <summary>
        /// 应用程序服务
        /// </summary>
        private readonly IQueryApplicationService _applicationService;

        /// <summary>
        /// 角色服务
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// 初始化用户身份配置服务
        /// </summary>
        /// <param name="claimsFactory">用户声明工厂</param>
        /// <param name="userManager">用户服务</param>
        /// <param name="applicationService">应用程序服务</param>
        /// <param name="roleService">角色服务</param>
        public ProfileService(IUserClaimsPrincipalFactory<User> claimsFactory, IdentityUserManager userManager,
            IQueryApplicationService applicationService, IRoleService roleService) : base(userManager, claimsFactory)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _applicationService = applicationService;
            _roleService = roleService;
        }

        /// <summary>
        /// 获取用户配置
        /// </summary>
        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context == null)
                return;
            var user = await GetUser(context);
            if (user == null)
                return;
            var principal = await _claimsFactory.CreateAsync(user);
            if (principal == null)
                return;
            var identity = principal.Identities.First();
            await AddApplicationClaims(context, identity);
            await AddRoleClaims(user, identity);
            context.AddRequestedClaims(principal.Claims);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        private async Task<User> GetUser(ProfileDataRequestContext context)
        {
            var userId = context.Subject?.GetSubjectId();
            if (userId.IsEmpty())
                return null;
            return await _userManager.FindByIdAsync(userId);
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        protected virtual async Task AddApplicationClaims(ProfileDataRequestContext context, ClaimsIdentity identity)
        {
            var application = await GetApplication(context);
            if (application == null)
                return;
            identity.AddClaim(new Claim(ClaimTypes.ApplicationId, application.Id));
            identity.AddClaim(new Claim(ClaimTypes.ApplicationCode, application.Code));
            identity.AddClaim(new Claim(ClaimTypes.ApplicationName, application.Name));
        }

        /// <summary>
        /// 获取应用程序
        /// </summary>
        private async Task<ApplicationDto> GetApplication(ProfileDataRequestContext context)
        {
            var applicationCode = context.Client?.ClientId;
            if (applicationCode.IsEmpty())
                return null;
            return await _applicationService.GetByCodeAsync(applicationCode);
        }

        /// <summary>
        /// 添加角色声明
        /// </summary>
        protected virtual async Task AddRoleClaims(User user, ClaimsIdentity identity)
        {
            var roles = await _roleService.GetRolesAsync(user.Id);
            if (roles == null || roles.Count == 0)
                return;
            identity.AddClaim(new Claim(ClaimTypes.RoleIds, roles.Select(t => t.Id).ToList().Join()));
            identity.AddClaim(new Claim(ClaimTypes.RoleName, roles.Select(t => t.Name).ToList().Join()));
        }
    }
}