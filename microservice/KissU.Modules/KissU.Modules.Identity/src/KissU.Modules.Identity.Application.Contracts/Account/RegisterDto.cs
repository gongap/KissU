using System.ComponentModel.DataAnnotations;
using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.Auditing;

namespace KissU.Modules.Identity.Application.Contracts.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(IdentityUserConsts.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(IdentityUserConsts.MaxEmailLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(IdentityUserConsts.MaxPasswordLength)]
        [DataType(DataType.Password)]
        [DisableAuditing]
        public string Password { get; set; }

        [Required]
        public string AppName { get; set; }
    }
}