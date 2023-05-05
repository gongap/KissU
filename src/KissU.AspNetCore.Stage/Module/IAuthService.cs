using System.Threading.Tasks;
using KissU.AspNetCore.Stage.Module.Implementation;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using Newtonsoft.Json.Linq;

namespace KissU.AspNetCore.Stage.Module
{
    /// <summary>
    /// AuthService
    /// </summary>
    [ServiceBundle("connect")]
    public interface IAuthService : IServiceKey
    {
        /// <summary>
        /// Request for token
        /// </summary>rns>
        Task<JObject> Token(AppTokenRequest parameters);

        /// <summary>
        /// Request for OAuth token revocation
        /// </summary>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task Revocation(AppRevocationRequest parameters);

        /// <summary>
        /// Request for OIDC userinfo
        /// </summary>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<string> UserInfo();
    }
}