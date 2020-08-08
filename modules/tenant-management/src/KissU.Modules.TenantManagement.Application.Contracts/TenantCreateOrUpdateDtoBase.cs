using System.ComponentModel.DataAnnotations;
using KissU.Modules.TenantManagement.Domain.Shared;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace KissU.Modules.TenantManagement.Application.Contracts
{
    public abstract class TenantCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.MaxNameLength))]
        public string Name { get; set; }
    }
}