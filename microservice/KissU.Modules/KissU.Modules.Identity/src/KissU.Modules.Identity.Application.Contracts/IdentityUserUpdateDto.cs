using System.ComponentModel.DataAnnotations;
using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityUserUpdateDto : IdentityUserCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        [StringLength(IdentityUserConsts.MaxPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }
        
        public string ConcurrencyStamp { get; set; }
    }
}