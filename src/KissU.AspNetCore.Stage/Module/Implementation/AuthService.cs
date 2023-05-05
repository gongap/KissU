using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KissU.AspNetCore.Internal;
using KissU.CPlatform.Cache;
using KissU.CPlatform.Ioc;
using KissU.Dependency;
using KissU.Exceptions;
using IdentityModel;
using IdentityModel.Client;
using IdentityServer4.AccessTokenValidation;
using KissUtil.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace KissU.AspNetCore.Stage.Module.Implementation;

/// <summary>
/// AuthService.
/// Implements the <see cref="ServiceBase" />
/// Implements the <see cref="IAuthService" />
/// </summary>
/// <seealso cref="ServiceBase" />
/// <seealso cref="IAuthService" />
[DisableConventionalRegistration]
public class AuthService : ServiceBase,  IAuthService
{
    private readonly ICacheProvider _cacheProvider;
    private const string  _tenantKey = "__tenant";

    public AuthService()
    {
        _cacheProvider = ServiceLocator.GetService<ICacheProvider>();
    }

    public async Task<JObject> Token(AppTokenRequest parameters)
    {
        if (parameters?.GrantType == OidcConstants.GrantTypes.ClientCredentials)
        {
            return await ClientCredentialsToken(parameters);
        }
        else if (parameters?.GrantType == OidcConstants.GrantTypes.Password)
        {
            return await PasswordToken(parameters);
        }
      
        return await PasswordToken(parameters, parameters?.GrantType);
    }

    public async Task<JObject> ClientCredentialsToken(AppTokenRequest parameters)
    {
        var tokenEndpoint = await GetTokenEndpoint();
        using var httpClient = new HttpClient();
        var tenantIdOrName = RestContext.GetContext().GetAttachment(_tenantKey).SafeString();
        var request = await CreateClientCredentialsTokenRequestAsync(tokenEndpoint, parameters);
        request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
        request.Headers.Add("__tenant", tenantIdOrName);
        var tokenResponse =  await httpClient.RequestClientCredentialsTokenAsync(request);
        if (tokenResponse.IsError)
        {
            if (tokenResponse.ErrorDescription == null)
            {
                throw new CPlatformCommunicationException($"Could not get token from the OpenId Connect server! Error: {tokenResponse.Error}. ");
            }

            throw new CPlatformCommunicationException(tokenResponse.ErrorDescription, tokenResponse.Error);
        }

        return tokenResponse.Json;
    }

    public async Task<JObject> PasswordToken(AppTokenRequest parameters,  string signInType = null)
    {
        var tokenEndpoint = await GetTokenEndpoint();
        using var httpClient = new HttpClient();
        var request = await CreatePasswordTokenRequestAsync(tokenEndpoint, parameters);
        var tenantIdOrName = RestContext.GetContext().GetAttachment(_tenantKey).SafeString();
        request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
        request.Headers.Add("__tenant", tenantIdOrName);
        AddParametersToRequestAsync(request, new Dictionary<string, string>
        {
            {"SignInType", signInType},
            {"ClientIpAddress", RestContext.GetContext().GetAttachment("RemoteIpAddress")?.SafeString()},
            {"BrowserInfo", RestContext.GetContext().GetAttachment("User-Agent")?.SafeString()},
        });
        var tokenResponse = await httpClient.RequestPasswordTokenAsync(request);
        if (tokenResponse.IsError)
        {
            if (tokenResponse.ErrorDescription == null)
            {
                throw new CPlatformCommunicationException($"Could not get token from the OpenId Connect server! Error: {tokenResponse.Error}. ");
            }

            throw new CPlatformCommunicationException(tokenResponse.ErrorDescription, tokenResponse.Error);
        }

        return tokenResponse.Json;
    }

    public async Task Revocation(AppRevocationRequest parameters)
    {
        var registrationEndpoint = await GetRevocationEndpoint();
        using var httpClient = new HttpClient();
        var tenantIdOrName = RestContext.GetContext().GetAttachment(_tenantKey).SafeString();
        var accessToken = RestContext.GetContext().GetAttachment("accessToken").SafeString();
        var request = await CreateTokenRevocationRequestAsync(registrationEndpoint, parameters, accessToken);
        request.Headers.Add("Accept-Language", CultureInfo.CurrentCulture.Name);
        request.Headers.Add("__tenant", tenantIdOrName);
        AddParametersToRequestAsync(request, new Dictionary<string, string>
        {
            {"payload",RestContext.GetContext().GetAttachment("payload").SafeString()},
            {"ClientId", parameters.ClientId},
            {"ClientIpAddress", RestContext.GetContext().GetAttachment("RemoteIpAddress")?.SafeString()},
            {"BrowserInfo", RestContext.GetContext().GetAttachment("User-Agent")?.SafeString()},
        });
        var tokenRevocationResponse =  await httpClient.RevokeTokenAsync(request);
        if (tokenRevocationResponse.IsError)
        {
            if (tokenRevocationResponse.Error != null)
            {
                throw new CPlatformCommunicationException($"Could not get revocation token from the OpenId Connect server! Error: {tokenRevocationResponse.Error}. ");
            }

            var rawError = tokenRevocationResponse.Raw;
            var withoutInnerException = rawError.Split(new string[] { "<eof/>" }, StringSplitOptions.RemoveEmptyEntries);
            throw new CPlatformCommunicationException(withoutInnerException[0]);
        }

        if (!tokenRevocationResponse.IsError && AppConfig.Options.AuthServer.EnableCaching)
        {
            var distributedCache = ServiceLocator.ServiceProvider?.GetService<IDistributedCache>();
            var identityServerAuthenticationOptions =  ServiceLocator.GetService<IOptions<IdentityServerAuthenticationOptions>>();
            var authenticationOption = identityServerAuthenticationOptions?.Value;
            var token = $"{authenticationOption?.CacheKeyPrefix}{accessToken}";
            await distributedCache?.RemoveAsync(Sha256(token));
        }
    }

    public Task<string> UserInfo()
    {
        return Task.FromResult(RestContext.GetContext().GetAttachment("payload").SafeString());
    }

    protected virtual async Task<string> GetTokenEndpoint()
    {
            var discoveryDocumentCacheItem = await GetIdentityModelDiscoveryDocumentCacheItem();
            return discoveryDocumentCacheItem.TokenEndpoint;
    }    
    
    protected virtual async Task<IdentityModelDiscoveryDocumentCacheItem> GetIdentityModelDiscoveryDocumentCacheItem()
    {
        var tokenEndpointUrlCacheKey = CalculateDiscoveryDocumentCacheKey();
        var discoveryDocumentCacheItem = await _cacheProvider.GetAsync<IdentityModelDiscoveryDocumentCacheItem>(tokenEndpointUrlCacheKey);
        if (discoveryDocumentCacheItem == null)
        {
            var discoveryResponse = await GetDiscoveryResponse();
            if (discoveryResponse.IsError)
            {
                throw new CPlatformCommunicationException($"Could not retrieve the OpenId Connect discovery document! Error: {discoveryResponse.Error}");
            }

            discoveryDocumentCacheItem = new IdentityModelDiscoveryDocumentCacheItem(discoveryResponse.TokenEndpoint,discoveryResponse.RevocationEndpoint);
             _cacheProvider.AddAsync(tokenEndpointUrlCacheKey, discoveryDocumentCacheItem,TimeSpan.FromMinutes(AppConfig.Options.AuthServer.DiscoveryDocumentCacheCacheDuration));
        }

        return discoveryDocumentCacheItem;
    }

    protected virtual async Task<string> GetRevocationEndpoint()
    {
        var discoveryDocumentCacheItem = await GetIdentityModelDiscoveryDocumentCacheItem();
        return discoveryDocumentCacheItem.RevocationEndpoint;
    }

    protected virtual async Task<DiscoveryDocumentResponse> GetDiscoveryResponse()
    {
        var authServer = AppConfig.Options.AuthServer;
        using var httpClient = new HttpClient();
        var request = new DiscoveryDocumentRequest
        {
            Address = authServer.Authority,
            Policy =
            {
                RequireHttps = authServer.RequireHttpsMetadata
            }
        };
        return await httpClient.GetDiscoveryDocumentAsync(request);
    }

    protected virtual Task<TokenRevocationRequest> CreateTokenRevocationRequestAsync(string registrationEndpoint, AppRevocationRequest revocationRequest, string accessToken)
    {
        var request = new TokenRevocationRequest
        {
            Address = registrationEndpoint,
            ClientId = revocationRequest.ClientId,
            ClientSecret = revocationRequest.ClientSecret,
            Token = accessToken,
        };

        return Task.FromResult(request);
    }

    protected virtual Task<PasswordTokenRequest> CreatePasswordTokenRequestAsync(string tokenEndpoint, AppTokenRequest tokenRequest)
    {
        var request = new PasswordTokenRequest
        {
            Address = tokenEndpoint,
            Scope = tokenRequest.Scope,
            ClientId = tokenRequest.ClientId,
            ClientSecret = tokenRequest.ClientSecret,
            UserName = tokenRequest.UserName,
            Password = tokenRequest.Password
        };

        return Task.FromResult(request);
    }

    protected virtual Task<ClientCredentialsTokenRequest> CreateClientCredentialsTokenRequestAsync(string tokenEndpoint, AppTokenRequest tokenRequest)
    {
        var request = new ClientCredentialsTokenRequest
        {
            Address = tokenEndpoint,
            Scope = tokenRequest.Scope,
            ClientId = tokenRequest.ClientId,
            ClientSecret = tokenRequest.ClientSecret
        };

        return Task.FromResult(request);
    }

    protected virtual void AddParametersToRequestAsync( ProtocolRequest request,IDictionary<string, string> parameters = null)
    {
        if (parameters?.Count > 0)
        {
            foreach (var pair in parameters)
            {
                request?.Parameters.Add(pair);
            }
        }
    }

    protected virtual string CalculateDiscoveryDocumentCacheKey()
    {
        return IdentityModelDiscoveryDocumentCacheItem.CalculateCacheKey();
    }

    private string Sha256(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;
        using SHA256 shA256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        return Convert.ToBase64String(shA256.ComputeHash(bytes));
    }
}
