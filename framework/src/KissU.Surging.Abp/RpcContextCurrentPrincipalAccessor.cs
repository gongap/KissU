using KissU.Surging.CPlatform.Transport.Implementation;
using System.Security.Claims;
using KissU.Surging.CPlatform.Filters.Implementation;
using Volo.Abp.Json;
using Volo.Abp.Security.Claims;
using System.Collections.Generic;
using KissU.Extensions;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

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
                if (claimTypes == null)
                {
                    return base.GetClaimsPrincipal();
                }

                var claims = new List<Claim>();
                foreach (var claimType in claimTypes)
                {
                    var type = InboundJwtClaimTypeMap(claimType.Key);
                    if (claimType.Value is JArray claimArray)
                    {
                        foreach (var item in claimArray)
                        {
                            claims.Add(new Claim(type, item.Value<string>()));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(type, claimType.Value.ToString()));
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

        private string InboundJwtClaimTypeMap(string claimType)
        {
            return claimType switch
            {
                "sub" => AbpClaimTypes.UserId,
                "role" => AbpClaimTypes.Role,
                "email" => AbpClaimTypes.Email,
                "email_verified" => AbpClaimTypes.EmailVerified,
                "phone_number" => AbpClaimTypes.PhoneNumber,
                "phone_number_verified" => AbpClaimTypes.PhoneNumberVerified,
                "name" => AbpClaimTypes.UserName,
                _ => claimType,
            };
        }
    }
}