using System.ComponentModel.DataAnnotations;

namespace KissU.Identity.Models.ManageViewModels
{
    /// <summary>
    /// 修改密码视图模型
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Initializes
        /// Initializes a new instance of the <see cref="ChangePasswordViewModel" /> class.
        /// </summary>
        /// <param name="statusMessage">The status message.</param>
        public ChangePasswordViewModel(string statusMessage)
        {
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// OldPassword
        /// </summary>
        /// <value>The old password.</value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>The new password.</value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        public string StatusMessage { get; set; }
    }
}
