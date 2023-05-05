using System.Security.Principal;

namespace KissU.WebSocket.Core.Net
{
    public interface IAuthenticator
    {
        IPrincipal Authenticate(string accessToken, string userInfoEndpoint);
    }
}
