using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace GreatWall.Configs {
    public class Config {
        public static IEnumerable<IdentityResource> GetIdentityResources() {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile ()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources() {
            return new List<ApiResource>
            {
                new ApiResource("api", "API") {
                    UserClaims = {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.PhoneNumber,
                        Util.Security.Claims.ClaimTypes.ApplicationId,
                        Util.Security.Claims.ClaimTypes.ApplicationCode,
                        Util.Security.Claims.ClaimTypes.ApplicationName,
                        Util.Security.Claims.ClaimTypes.RoleIds,
                        Util.Security.Claims.ClaimTypes.RoleName
                    }
                }
            };
        }

        public const int AccessTokenLifetime = 90000000;

        public const string AdminUrl = "http://localhost:1927";

        public static IEnumerable<Client> GetClients() {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "AdminConsole",
                    ClientName = "权限管理后台",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = { AdminUrl },
                    RequireConsent = false,
                    RedirectUris = { $"{AdminUrl}/callback" },
                    PostLogoutRedirectUris = { AdminUrl },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    },
                    AccessTokenLifetime = AccessTokenLifetime
                }
            };
        }
    }
}