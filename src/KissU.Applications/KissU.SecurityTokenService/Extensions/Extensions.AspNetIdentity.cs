using System;
using KissU.Modules.GreatWall.Data.Repositories;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Implements;
using KissU.Modules.GreatWall.Domain.Shared.Describers;
using KissU.Modules.GreatWall.Domain.Shared.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.SecurityTokenService.Extensions
{
    /// <summary>
    /// AspNetIdentity扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 添加AspNetIdentity服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">配置操作</param>
        public static IServiceCollection AspNetIdentity(this IServiceCollection services, Action<PermissionOptions> setupAction = null)
        {
            var permissionOptions = new PermissionOptions();
            setupAction?.Invoke(permissionOptions);
            services.AddIdentity<User, Role>()
                .AddUserStore<UserRepository>().AddRoleStore<RoleRepository>()
                .AddUserManager<IdentityUserManager>().AddRoleManager<IdentityRoleManager>().AddSignInManager<IdentitySignInManager>()
                .AddDefaultTokenProviders();
            services.AddScoped<IdentityErrorDescriber, IdentityErrorChineseDescriber>();
            return services;
        }
    }
}