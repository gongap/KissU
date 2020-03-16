using System.ComponentModel.DataAnnotations;

namespace KissU.Services.Identity.Models.ManageViewModels
{
    /// <summary>
    /// Class IndexViewModel.
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is email confirmed.
        /// </summary>
        /// <value><c>true</c> if this instance is email confirmed; otherwise, <c>false</c>.</value>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        public string StatusMessage { get; set; }
    }
}
