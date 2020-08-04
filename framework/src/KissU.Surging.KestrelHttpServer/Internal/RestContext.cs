using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using KissU.Helpers;
using KissU.Serialization.Implementation;

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]

        public void SetClaimsPrincipal(string key, ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var claimTypes = claimsPrincipal.Identities.SelectMany(x => x.Claims).GroupBy(x => x.Type).ToDictionary(y => y.Key, m => m.Select(n => n.Value).ToList());
                SetAttachment(key, new JsonSerializer().Serialize(claimTypes));
            }
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
    }
}