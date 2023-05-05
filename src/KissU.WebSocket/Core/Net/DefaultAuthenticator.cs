using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport.Implementation;
using KissU.Dependency;
using KissU.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;

namespace KissU.WebSocket.Core.Net;

public class DefaultAuthenticator : IAuthenticator
{
    private readonly ILogger _logger;

    public DefaultAuthenticator(ILogger<DefaultAuthenticator> logger)
    {
        _logger = logger;
    }

    public IPrincipal Authenticate(string accessToken, string userInfoEndpoint)
    {
        if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(userInfoEndpoint))
        {
            return null;
        }

        IPrincipal user = null;
        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var tokenResponse = httpClient.GetAsync(userInfoEndpoint).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var responseString = tokenResponse.Content.ReadAsStringAsync().Result;
                var jsonSerializer = ServiceLocator.GetService<ISerializer<string>>();
                var httpResultMessage = jsonSerializer.Deserialize<string, HttpResultMessage<Dictionary<string, List<string>>>>(responseString);
                if (httpResultMessage.IsSucceed)
                {
                    var claimTypes = httpResultMessage.Result;
                    user = CreatePrincipal(claimTypes);
                    RpcContext.GetContext().SetAttachment("payload", jsonSerializer.Serialize(claimTypes));
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogWarning(e.GetBaseException().Message);
        }

        return user;
    }

    private ClaimsPrincipal CreatePrincipal( IDictionary<string, List<string>> claimTypes)
    {
        if (claimTypes?.Count > 0)
        {
            var claims = new List<Claim>();
            foreach (var claimType in claimTypes)
            {
                foreach (var item in claimType.Value)
                {
                    claims.Add(new Claim(claimType.Key, item));
                }
            }

            if (claims.Any())
            {
                return new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtBearer"));
            }
        }

        return null;
    }
}
