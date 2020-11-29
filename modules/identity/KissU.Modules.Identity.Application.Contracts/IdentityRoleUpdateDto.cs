using Volo.Abp.Domain.Entities;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityRoleUpdateDto : IdentityRoleCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}