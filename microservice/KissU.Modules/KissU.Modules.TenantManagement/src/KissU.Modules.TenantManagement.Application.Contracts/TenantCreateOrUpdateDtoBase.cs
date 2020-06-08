using System.ComponentModel.DataAnnotations;
using KissU.Modules.TenantManagement.Domain.Shared;
using Volo.Abp.ObjectExtending;

namespace KissU.Modules.TenantManagement.Application.Contracts
{
    public abstract class TenantCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [StringLength(TenantConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}