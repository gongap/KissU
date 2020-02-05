using System.Security.Claims;
using KissU.Util.Security.Principals;
using Microsoft.AspNetCore.Http;

namespace KissU.Util.AspNetCore
{
    /// <summary>
    /// 系统扩展 - 安全
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 获取用户标识声明值
        /// </summary>
        /// <param name="identity">用户标识</param>
        /// <param name="type">声明类型</param>
        /// <returns>System.String.</returns>
        public static string GetValue(this ClaimsIdentity identity, string type)
        {
            var claim = identity.FindFirst(type);
            if (claim == null)
                return string.Empty;
            return claim.Value;
        }

        /// <summary>
        /// 获取身份标识
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <returns>ClaimsIdentity.</returns>
        public static ClaimsIdentity GetIdentity(this HttpContext context)
        {
            var principal = context?.User;
            if (principal == null)
                return UnauthenticatedIdentity.Instance;
            if (principal.Identity is ClaimsIdentity identity)
                return identity;
            return UnauthenticatedIdentity.Instance;
        }
    }
}