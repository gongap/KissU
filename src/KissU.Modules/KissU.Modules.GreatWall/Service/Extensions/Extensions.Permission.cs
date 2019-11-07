using System;
using KissU.Modules.GreatWall.Data.Repositories;
using KissU.IModuleServices.GreatWall.Infrastructure.Describers;
using KissU.IModuleServices.GreatWall.Infrastructure.Extensions;
using KissU.IModuleServices.GreatWall.Infrastructure.Options;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Services.Implements;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.GreatWall.Service.Extensions
{
    /// <summary>
    /// 权限扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 添加权限服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">配置操作</param>
        public static IServiceCollection AddPermission(this IServiceCollection services, Action<PermissionOptions> setupAction = null)
        {
            var permissionOptions = new PermissionOptions();
            setupAction?.Invoke(permissionOptions);
            services.AddScoped<IdentityUserManager>();
            services.AddScoped<IdentitySignInManager>();
            services.AddIdentity<User, Role>(options => options.Load(permissionOptions))
                .AddUserStore<UserRepository>()
                .AddRoleStore<RoleRepository>()
                .AddDefaultTokenProviders();
            services.AddScoped<IdentityErrorDescriber, IdentityErrorChineseDescriber>();
            services.AddLogging();
            return services;
        }
    }
}