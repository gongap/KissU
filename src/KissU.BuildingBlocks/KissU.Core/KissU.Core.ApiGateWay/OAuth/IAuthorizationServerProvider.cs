using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.ApiGateWay.OAuth
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
        /// Refreshes the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> RefreshToken(string token);

        /// <summary>
        /// Gets the payload string.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>System.String.</returns>
        string GetPayloadString(string token);
    }
}