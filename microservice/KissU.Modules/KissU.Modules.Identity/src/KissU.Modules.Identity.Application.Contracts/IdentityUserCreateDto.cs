using System.ComponentModel.DataAnnotations;
using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.Auditing;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityUserCreateDto : IdentityUserCreateOrUpdateDtoBase
    {
        [Required]
        [StringLength(IdentityUserConsts.MaxPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }
    }
}