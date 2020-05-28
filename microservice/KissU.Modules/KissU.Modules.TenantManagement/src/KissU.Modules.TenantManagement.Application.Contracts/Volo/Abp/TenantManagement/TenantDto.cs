using System;
using Volo.Abp.Application.Dtos;

namespace KissU.Modules.TenantManagement
{
    public class TenantDto : ExtensibleEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}