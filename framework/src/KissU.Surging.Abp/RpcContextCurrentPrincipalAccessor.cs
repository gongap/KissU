using KissU.Surging.CPlatform.Transport.Implementation;
using System.Security.Claims;
using KissU.Surging.CPlatform.Filters.Implementation;
using Volo.Abp.Json;
using Volo.Abp.Security.Claims;
using System.Collections.Generic;
using KissU.Extensions;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace KissU.Surging.Abp
{
    public class RpcContextCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
    {
        private readonly IJsonSerializer _jsonSerializer;

        public RpcContextCurrentPrincipalAccessor(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        protected override ClaimsPrincipal GetClaimsPrincipal()
        {
            return GetPrincipal();
        }

        private ClaimsPrincipal GetPrincipal()
        {
            try
            {
                var payload = RpcContext.GetContext().GetAttachment("payload").SafeString();
                var claimTypes = _jsonSerializer.Deserialize<IDictionary<string, object>>(payload);
                var claims = new List<Claim>();
                foreach (var claimType in claimTypes)
                {
                    if (claimType.Value is JArray claimArray)
                    {
                        foreach (var item in claimArray)
                        {
                            claims.Add(new Claim(claimType.Key, item.Value<string>()));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(claimType.Key, claimType.Value.ToString()));
                    }
                }

                if (claims.Any())
                {
                    var claimsIdentity = new ClaimsIdentity(claims, nameof(AuthorizationType.JWTBearer));
                    return new ClaimsPrincipal(claimsIdentity);
                }
            }
            catch
            {
                return base.GetClaimsPrincipal();
            }

            return base.GetClaimsPrincipal();
        }
    }
}