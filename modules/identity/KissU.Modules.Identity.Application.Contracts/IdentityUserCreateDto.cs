using System.ComponentModel.DataAnnotations;
using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.Validation;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityUserCreateDto : IdentityUserCreateOrUpdateDtoBase
    {
        [DisableAuditing]
        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
        public string Password { get; set; }
    }
}