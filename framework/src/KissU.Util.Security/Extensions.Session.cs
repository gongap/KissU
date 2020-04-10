using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using KissU.Core;
using KissU.Core.Sessions;
using KissU.Util.AspNetCore;
using KissU.Util.AspNetCore.Helpers;
using Convert = KissU.Core.Helpers.Convert;

namespace KissU.Util.Security
{
    /// <summary>
    /// 用户会话扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 获取当前操作人标识
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>Guid.</returns>
        public static Guid GetUserId(this ISession session)
        {
            return session.UserId.ToGuid();
        }

        /// <summary>
        /// 获取当前操作人标识
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">用户会话</param>
        /// <returns>T.</returns>
        public static T GetUserId<T>(this ISession session)
        {
            return Convert.To<T>(session.UserId);
        }

        /// <summary>
        /// 获取当前操作人用户名
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetUserName(this ISession session)
        {
            var result = Web.Identity.GetValue(JwtClaimTypes.Name);
            return string.IsNullOrWhiteSpace(result) ? Web.Identity.GetValue(ClaimTypes.Name) : result;
        }

        /// <summary>
        /// 获取当前操作人姓名
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetFullName(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.FullName);
        }

        /// <summary>
        /// 获取当前操作人电子邮件
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetEmail(this ISession session)
        {
            var result = Web.Identity.GetValue(JwtClaimTypes.Email);
            return string.IsNullOrWhiteSpace(result) ? Web.Identity.GetValue(ClaimTypes.Email) : result;
        }

        /// <summary>
        /// 获取当前操作人手机号
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetMobile(this ISession session)
        {
            var result = Web.Identity.GetValue(JwtClaimTypes.PhoneNumber);
            return string.IsNullOrWhiteSpace(result) ? Web.Identity.GetValue(ClaimTypes.MobilePhone) : result;
        }

        /// <summary>
        /// 获取当前应用程序标识
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>Guid.</returns>
        public static Guid GetApplicationId(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.ApplicationId).ToGuid();
        }

        /// <summary>
        /// 获取当前应用程序标识
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">用户会话</param>
        /// <returns>T.</returns>
        public static T GetApplicationId<T>(this ISession session)
        {
            return Convert.To<T>(Web.Identity.GetValue(Claims.ClaimTypes.ApplicationId));
        }

        /// <summary>
        /// 获取当前应用程序编码
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetApplicationCode(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.ApplicationCode);
        }

        /// <summary>
        /// 获取当前应用程序名称
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetApplicationName(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.ApplicationName);
        }

        /// <summary>
        /// 获取当前租户标识
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>Guid.</returns>
        public static Guid GetTenantId(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.TenantId).ToGuid();
        }

        /// <summary>
        /// 获取当前租户标识
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">用户会话</param>
        /// <returns>T.</returns>
        public static T GetTenantId<T>(this ISession session)
        {
            return Convert.To<T>(Web.Identity.GetValue(Claims.ClaimTypes.TenantId));
        }

        /// <summary>
        /// 获取当前租户编码
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetTenantCode(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.TenantCode);
        }

        /// <summary>
        /// 获取当前租户名称
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetTenantName(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.TenantName);
        }

        /// <summary>
        /// 获取当前操作人角色标识列表
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>List&lt;Guid&gt;.</returns>
        public static List<Guid> GetRoleIds(this ISession session)
        {
            return session.GetRoleIds<Guid>();
        }

        /// <summary>
        /// 获取当前操作人角色标识列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">用户会话</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> GetRoleIds<T>(this ISession session)
        {
            return Convert.ToList<T>(Web.Identity.GetValue(Claims.ClaimTypes.RoleIds));
        }

        /// <summary>
        /// 获取当前操作人角色名
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>System.String.</returns>
        public static string GetRoleName(this ISession session)
        {
            return Web.Identity.GetValue(Claims.ClaimTypes.RoleName);
        }
    }
}