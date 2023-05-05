using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.ApiGateWay.OAuth
{
    /// <summary>
    /// Interface IAuthorizationServerProvider
    /// </summary>
    public interface IAuthorizationServerProvider
    {
        /// <summary>
        /// Generates the token credential.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GenerateTokenCredential(Dictionary<string, object> parameters);

        /// <summary>
        /// Validates the client authentication.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ValidateClientAuthentication(string token);

        /// <summary>
        /// Validates the AppSecret authentication.
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ValidateAppSecretAuthentication(string token,  string appSecret,  long? timestamp);

        /// <summary>
        /// Revocation the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task Revocation(string token);

        /// <summary>
        /// Gets the payload string.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>System.String.</returns>
        string GetPayloadString(string token);
    }
}
