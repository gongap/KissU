using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Transport.Implementation;
using KissU.Extensions;
using Newtonsoft.Json.Linq;
using Volo.Abp.Json;
using Volo.Abp.Security.Claims;

namespace KissU.Abp.Business
{
    public class AbpCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
    {
        private readonly IJsonSerializer _jsonSerializer;

        public AbpCurrentPrincipalAccessor(IJsonSerializer jsonSerializer)
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