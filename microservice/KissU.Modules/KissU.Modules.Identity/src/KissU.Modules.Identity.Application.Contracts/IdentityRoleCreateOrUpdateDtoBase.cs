using System.ComponentModel.DataAnnotations;
using KissU.Modules.Identity.Domain.Shared;
using Volo.Abp.ObjectExtending;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityRoleCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [StringLength(IdentityRoleConsts.MaxNameLength)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPublic { get; set; }
    }
}