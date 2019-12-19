using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using KFNets.Microservices.IdentityServer.Services;
using KissU.Modules.GreatWall.Data.Repositories;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Implements;
using KissU.Modules.GreatWall.Domain.Shared.Describers;
using KissU.Modules.GreatWall.Domain.Shared.Extensions;
using KissU.Modules.GreatWall.Domain.Shared.Options;

namespace KFNets.Microservices.IdentityServer.Extensions
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
            // 配置密码的验证逻辑
            permissionOptions.Password.MinLength = 6;
            permissionOptions.Password.NonAlphanumeric = true;
            permissionOptions.Password.Uppercase = true;
            permissionOptions.Password.Digit = true;
            setupAction?.Invoke(permissionOptions);
            services.AddIdentity<User, Role>(options => options.Load(permissionOptions))
                .AddUserStore<UserRepository>().AddRoleStore<RoleRepository>()
                .AddUserManager<IdentityUserManager>().AddRoleManager<IdentityRoleManager>().AddSignInManager<IdentitySignInManager>()
                .AddDefaultTokenProviders();
            services.AddScoped<IdentityErrorDescriber, IdentityErrorChineseDescriber>();
            services.AddLogging();
            return services;
        }
    }
}
