using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Util.Security.Claims;

namespace KissU.AuthenticationServer.Configs
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "API")
                {
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.PhoneNumber,
                        ClaimTypes.ApplicationId,
                        ClaimTypes.ApplicationCode,
                        ClaimTypes.ApplicationName,
                        ClaimTypes.RoleIds,
                        ClaimTypes.RoleName
                    }
                }
            };
        }

        public const int AccessTokenLifetime = 90000000;

        public const string AdminUrl = "http://localhost:1927";

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "AdminConsole",
                    ClientName = "权限管理后台",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = {AdminUrl},
                    RequireConsent = false,
                    RedirectUris = {$"{AdminUrl}/callback"},
                    PostLogoutRedirectUris = {AdminUrl},
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