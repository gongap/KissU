using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.ApiGateWay.OAuth
{
    public interface IAuthorizationServerProvider
    {
        Task<string> GenerateTokenCredential(Dictionary<string, object> parameters);

        Task<bool> ValidateClientAuthentication(string token);

        Task<bool> RefreshToken(string token);

        string GetPayloadString(string token);
    }
}
