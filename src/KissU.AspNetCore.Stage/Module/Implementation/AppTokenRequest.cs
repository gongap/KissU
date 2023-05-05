using System.ComponentModel.DataAnnotations;

namespace KissU.AspNetCore.Stage.Module.Implementation
{
    /// <summary>
    /// Get token from the OpenId Connect server
    /// </summary>
    public class AppTokenRequest
    {
        /// <summary>
        /// Possible values: , "password", "phone_captcha" or "client_credentials".
        /// Default value: "password".
        /// </summary>
        [Required]
        public string GrantType { get; set; } = "password";

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        /// <value>The client secret.</value>
        [Required]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>The scope.</value>
        [Required]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}