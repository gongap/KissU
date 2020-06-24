using System.Collections.Generic;

namespace KissU.Surging.Kestrel.Swagger.Swagger.Model
{
    /// <summary>
    /// OAuth2Scheme.
    /// Implements the <see cref="SecurityScheme" />
    /// </summary>
    /// <seealso cref="SecurityScheme" />
    public class OAuth2Scheme : SecurityScheme
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2Scheme" /> class.
        /// </summary>
        public OAuth2Scheme()
        {
            Type = "oauth2";
        }

        /// <summary>
        /// Gets or sets the flow.
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// Gets or sets the authorization URL.
        /// </summary>
        public string AuthorizationUrl { get; set; }

        /// <summary>
        /// Gets or sets the token URL.
        /// </summary>
        public string TokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the scopes.
        /// </summary>
        public IDictionary<string, string> Scopes { get; set; }
    }
}