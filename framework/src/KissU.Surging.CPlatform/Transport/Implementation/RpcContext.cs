﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading;
using KissU.Core.Security.Principals;
using KissU.Surging.CPlatform.Filters.Implementation;

namespace KissU.Surging.CPlatform.Transport.Implementation
{
    /// <summary>
    /// Rpc上下文.
    /// </summary>
    public class RpcContext
    {
        private static readonly AsyncLocal<RpcContext> rpcContextThreadLocal = new AsyncLocal<RpcContext>();
        private ConcurrentDictionary<string, object> contextParameters;

        private RpcContext()
        {
        }

        /// <summary>
        /// 获取上下文参数.
        /// </summary>
        /// <returns>ConcurrentDictionary&lt;String, Object&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ConcurrentDictionary<string, object> GetContextParameters()
        {
            return contextParameters;
        }

        /// <summary>
        /// 设置附件.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAttachment(string key, object value)
        {
            contextParameters.AddOrUpdate(key, value, (k, v) => value);
        }

        /// <summary>
        /// 获取附件.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetAttachment(string key)
        {
            contextParameters.TryGetValue(key, out var result);
            return result;
        }

        /// <summary>
        /// 设置上下文参数.
        /// </summary>
        /// <param name="contextParameters">The context parameters.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetContextParameters(ConcurrentDictionary<string, object> contextParameters)
        {
            this.contextParameters = contextParameters;
        }

        /// <summary>
        /// 获取上下文.
        /// </summary>
        /// <returns>RpcContext.</returns>
        public static RpcContext GetContext()
        {
            var context = rpcContextThreadLocal.Value;

            if (context == null)
            {
                context = new RpcContext();
                context.SetContextParameters(new ConcurrentDictionary<string, object>());
                rpcContextThreadLocal.Value = context;
            }

            return rpcContextThreadLocal.Value;
        }

        /// <summary>
        /// 删除上下文.
        /// </summary>
        public static void RemoveContext()
        {
            rpcContextThreadLocal.Value = null;
        }

        #region User(当前用户安全主体)

        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static ClaimsPrincipal User
        {
            get
            {
                var payload = GetContext().GetAttachment("payload");
                var principal = GetPrincipal((IDictionary<string, object>)payload);
                return principal ?? UnauthenticatedPrincipal.Instance;
            }
        }

        private static ClaimsPrincipal GetPrincipal(IDictionary<string, object> payload)
        {
            var claims = new List<Claim>();
            foreach (var item in payload) claims.Add(new Claim(item.Key, item.Value.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault()));
            var identity = new ClaimsIdentity(claims, System.Enum.GetName(typeof(AuthorizationType), AuthorizationType.JWTBearer));
            var claimsPrincipal = new ClaimsPrincipal(identity);
            return claimsPrincipal;
        }

        #endregion

        #region Identity(当前用户身份)

        /// <summary>
        /// 当前用户身份
        /// </summary>
        public static ClaimsIdentity Identity
        {
            get
            {
                if (User.Identity is ClaimsIdentity identity)
                    return identity;
                return UnauthenticatedIdentity.Instance;
            }
        }

        #endregion
    }
}