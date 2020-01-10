using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using KissU.Modules.GreatWall.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace KissU.Modules.GreatWall.Domain.Services.Implements
{
    /// <summary>
    /// Identity角色服务
    /// </summary>
    public class IdentityRoleManager : RoleManager<Role>
    {
        /// <summary>
        /// 初始化Identity角色服务
        /// </summary>
        /// <param name="store">角色存储</param>
        /// <param name="roleValidators">角色验证器</param>
        /// <param name="keyNormalizer">键标准化器</param>
        /// <param name="errors">中文错误描述</param>
        /// <param name="logger">日志</param>
        public IdentityRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger, IHttpContextAccessor contextAccessor) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
