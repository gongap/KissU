using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.IdentityServer.Domain.ApiResources;
using KissU.Modules.IdentityServer.Domain.Clients;
using KissU.Modules.IdentityServer.Domain.IdentityResources;
using KissU.Modules.PermissionManagement.Domain;
using KissU.Modules.TenantManagement.Application.Contracts;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace KissU.AuthServer.Host
{
    public class AuthServerDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IClientRepository _clientRepository;
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;

        public AuthServerDataSeeder(
            IClientRepository clientRepository,
            IApiResourceRepository apiResourceRepository,
            IIdentityResourceDataSeeder identityResourceDataSeeder,
            IGuidGenerator guidGenerator,
            IPermissionDataSeeder permissionDataSeeder)
        {
            _clientRepository = clientRepository;
            _apiResourceRepository = apiResourceRepository;
            _identityResourceDataSeeder = identityResourceDataSeeder;
            _guidGenerator = guidGenerator;
            _permissionDataSeeder = permissionDataSeeder;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _identityResourceDataSeeder.CreateStandardResourcesAsync();
            await CreateApiResourcesAsync();
            await CreateClientsAsync();
        }

        private async Task CreateApiResourcesAsync()
        {
            var commonApiUserClaims = new[]
            {
                "email",
                "email_verified",
                "name",
                "phone_number",
                "phone_number_verified",
                "role"
            };

            await CreateApiResourceAsync("IdentityService", commonApiUserClaims);
            await CreateApiResourceAsync("TenantManagementService", commonApiUserClaims);
            await CreateApiResourceAsync("BloggingService", commonApiUserClaims);
            await CreateApiResourceAsync("ProductService", commonApiUserClaims);
            await CreateApiResourceAsync("InternalGateway", commonApiUserClaims);
            await CreateApiResourceAsync("BackendAdminAppGateway", commonApiUserClaims);
            await CreateApiResourceAsync("PublicWebSiteGateway", commonApiUserClaims);
        }

        private async Task<ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
        {
            var apiResource = await _apiResourceRepository.FindByNameAsync(name);
            if (apiResource == null)
            {
                apiResource = await _apiResourceRepository.InsertAsync(
                    new ApiResource(
                        _guidGenerator.Create(),
                        name,
                        name + " API"
                    ),
                    autoSave: true
                );
            }

            foreach (var claim in claims)
            {
                if (apiResource.FindClaim(claim) == null)
                {
                    apiResource.AddUserClaim(claim);
                }
            }

            return await _apiResourceRepository.UpdateAsync(apiResource);
        }

        private async Task CreateClientsAsync()
        {
            const string commonSecret = "E5Xd4yMqjP5kjWFKrYgySBju6JVfCzMyFp7n2QmMrME=";

            var commonScopes = new[]
            {
                "email",
                "openid",
                "profile",
                "role",
                "phone",
                "address"
            };

            await CreateClientAsync(
                "console-client-demo",
                new[] { "BloggingService", "IdentityService", "InternalGateway", "ProductService", "TenantManagementService" },
                new[] { "client_credentials", "password" },
                commonSecret,
                permissions: new[] { IdentityPermissions.Users.Default, TenantManagementPermissions.Tenants.Default, "ProductManagement.Product" }
            );

            await CreateClientAsync(
                "backend-admin-app-client",
                commonScopes.Union(new[] { "BackendAdminAppGateway", "IdentityService", "ProductService", "TenantManagementService" }),
                new[] { "hybrid" },
                commonSecret,
                permissions: new[] { IdentityPermissions.Users.Default, "ProductManagement.Product" },
                redirectUris: new[] {"http://localhost:51954/signin-oidc"},
                postLogoutRedirectUris: new[] {"http://localhost:51954/signout-callback-oidc"}
            );

            await CreateClientAsync(
                "public-website-client",
                commonScopes.Union(new[] { "PublicWebSiteGateway", "BloggingService", "ProductService" }),
                new[] { "hybrid" },
                commonSecret,
                redirectUris: new[] {"http://localhost:53435/signin-oidc"},
                postLogoutRedirectUris: new[] {"http://localhost:53435/signout-callback-oidc"}
            );

            await CreateClientAsync(
                "blogging-service-client",
                new[] { "InternalGateway", "IdentityService" },
                new[] { "client_credentials" },
                commonSecret,
                permissions: new[] { IdentityPermissions.UserLookup.Default }
            );

            await CreateClientAsync(
                "angularImplicitClient",
                commonScopes,
                new[] { "implicit"},
                commonSecret,
                redirectUris: new[] { "http://localhost:4200", "http://localhost:4200/silent-renew.html" },
                allowedCorsOrigins: new[] { "http://localhost:4200" },
                postLogoutRedirectUris: new[] {"http://localhost:4200" },
                config : client =>
                {
                    client.AllowAccessTokensViaBrowser = true;
                    client.AllowOfflineAccess = true;
                    client.FrontChannelLogoutUri = "http://localhost:4200";
                }
            );
          
        }

        private async Task<Client> CreateClientAsync(
            string name,
            IEnumerable<string> scopes,
            IEnumerable<string> grantTypes,
            string secret,
            IEnumerable<string> redirectUris = null,
            IEnumerable<string> postLogoutRedirectUris = null,
            IEnumerable<string> allowedCorsOrigins = null,
            IEnumerable<string> permissions = null,
            Action<Client> config = null)
        {
            var client = await _clientRepository.FindByCliendIdAsync(name);
            if (client == null)
            {
                client = await _clientRepository.InsertAsync(new Client(
                    _guidGenerator.Create(),
                    name
                )
                {
                    ClientName = name,
                    ProtocolType = "oidc",
                    Description = name,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    AbsoluteRefreshTokenLifetime = 31536000, //365 days
                    AccessTokenLifetime = 31536000, //365 days
                    AuthorizationCodeLifetime = 300,
                    IdentityTokenLifetime = 300,
                    RequireConsent = false,
                }, autoSave: true);
            }

            foreach (var scope in scopes)
            {
                if (client.FindScope(scope) == null)
                {
                    client.AddScope(scope);
                }
            }

            foreach (var grantType in grantTypes)
            {
                if (client.FindGrantType(grantType) == null)
                {
                    client.AddGrantType(grantType);
                }
            }

            if (client.FindSecret(secret) == null)
            {
                client.AddSecret(secret);
            }

            if (redirectUris != null)
            {
                foreach (var redirectUri in redirectUris)
                {
                    if (client.FindRedirectUri(redirectUri) == null)
                    {
                        client.AddRedirectUri(redirectUri);
                    }
                }
            }

            if (postLogoutRedirectUris != null)
            {
                foreach (var postLogoutRedirectUri in postLogoutRedirectUris)
                {
                    if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) == null)
                    {
                        client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
                    }
                }
            }            
            
            if (allowedCorsOrigins != null)
            {
                foreach (var allowedCorsOrigin in allowedCorsOrigins)
                {
                    if (client.FindCorsOrigin(allowedCorsOrigin) == null)
                    {
                        client.AddCorsOrigin(allowedCorsOrigin);
                    }
                }
            }

            if (permissions != null)
            {
                await _permissionDataSeeder.SeedAsync(
                    ClientPermissionValueProvider.ProviderName,
                    client.ClientId,
                    permissions
                );
            }

            config?.Invoke(client);

            return await _clientRepository.UpdateAsync(client);
        }
    }
}
