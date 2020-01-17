using System.ComponentModel.DataAnnotations;

namespace KissU.IdentityServer.Quickstart.Account
{
    /// <summary>
    /// LoginInputModel.
    /// </summary>
    public class LoginInputModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [remember login].
        /// </summary>
        /// <value><c>true</c> if [remember login]; otherwise, <c>false</c>.</value>
        public bool RememberLogin { get; set; }
        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
        public string ReturnUrl { get; set; }
    }
}