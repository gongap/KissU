using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using KissU.CPlatform.Transport.Implementation;
using KissU.Extensions;
using KissU.Serialization;
using Newtonsoft.Json.Linq;
using Volo.Abp.Json;
using Volo.Abp.Security.Claims;

namespace KissU.Abp
{
    public class AbpCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
    {
        private readonly ISerializer<string> _jsonSerializer;

        public AbpCurrentPrincipalAccessor(ISerializer<string> jsonSerializer)
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
                var claimTypes = _jsonSerializer.Deserialize<string, IDictionary<string, List<string>>>(payload);
                if (claimTypes == null)
                {
                    return base.GetClaimsPrincipal();
                }

                var claims = new List<Claim>();
                foreach (var claimType in claimTypes)
                {
                    var type = InboundJwtClaimTypeMap(claimType.Key);
                    foreach (var item in claimType.Value)
                    {
                        claims.Add(new Claim(type, item));
                    }
                }

                if (claims.Any())
                {
                    var claimsIdentity = new ClaimsIdentity(claims);
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