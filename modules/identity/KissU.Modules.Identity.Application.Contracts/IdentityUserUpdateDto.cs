using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityUserUpdateDto : IdentityUserCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        [DisableAuditing]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
        public string Password { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}