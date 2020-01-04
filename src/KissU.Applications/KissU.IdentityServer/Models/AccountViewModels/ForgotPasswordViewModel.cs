using System.ComponentModel.DataAnnotations;

namespace KissU.IdentityServer.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
