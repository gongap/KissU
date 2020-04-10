using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KissU.Services.Identity.Models.ManageViewModels
{
    /// <summary>
    /// Class EnableAuthenticatorViewModel.
    /// </summary>
    public class EnableAuthenticatorViewModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Verification Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the shared key.
        /// </summary>
        /// <value>The shared key.</value>
        [ReadOnly(true)]
        public string SharedKey { get; set; }

        /// <summary>
        /// Gets or sets the authenticator URI.
        /// </summary>
        /// <value>The authenticator URI.</value>
        public string AuthenticatorUri { get; set; }
    }
}
