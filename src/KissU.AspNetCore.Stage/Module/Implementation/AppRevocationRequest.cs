using System.ComponentModel.DataAnnotations;

namespace KissU.AspNetCore.Stage.Module.Implementation
{
    /// <summary>
    ///  Revocation token from the OpenId Connect server
    /// </summary>
    public class AppRevocationRequest
    {
        /// <summary>Gets or sets the client identifier.</summary>
        /// <value>The client identifier.</value>
        [Required]
        public string ClientId { get; set; }

        /// <summary>Gets or sets the client secret.</summary>
        /// <value>The client secret.</value>
        /// [Required]
        public string ClientSecret { get; set; }
    }
}
