using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using KissU.Core.Security.Principals;
using KissU.Core.Utilities;
using KissU.Surging.CPlatform.Filters.Implementation;

namespace KissU.Surging.KestrelHttpServer.Internal
{
    public class RestContext
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAttachment(string key, object value)
        {
            Check.NotNull(serviceProvider, "serviceProvider");
            var htpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            htpContextAccessor.HttpContext.Items.Add(key, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetAttachment(string key)
        {
            Check.NotNull(serviceProvider, "serviceProvider");
            var htpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            htpContextAccessor.HttpContext.Items.TryGetValue(key, out object value);
            return value;
        }

        public void RemoveContextParameters(string key)
        {
            Check.NotNull(serviceProvider, "serviceProvider");
            var htpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            if (htpContextAccessor.HttpContext.Items.ContainsKey(key))
                htpContextAccessor.HttpContext.Items.Remove(key);

        }

        public Dictionary<string, object> GetContextParameters()
        {
            Check.NotNull(serviceProvider, "serviceProvider");
            var htpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            return htpContextAccessor.HttpContext.Items.ToDictionary(p => p.Key.ToString(), m => m.Value);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetContextParameters(IDictionary<object, object> contextParameters)
        {
            Check.NotNull(serviceProvider, "serviceProvider");
            var htpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            htpContextAccessor.HttpContext.Items = contextParameters;
        }

        private static IServiceProvider serviceProvider;

        internal void Initialize(IServiceProvider provider)
        {
            serviceProvider = provider;
        }

        public static RestContext GetContext()
        {
            return new RestContext();
        }

        public static void RemoveContext()
        {
            Check.NotNull(serviceProvider, "serviceProvider");
            var htpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            htpContextAccessor.HttpContext.Items.Clear();

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