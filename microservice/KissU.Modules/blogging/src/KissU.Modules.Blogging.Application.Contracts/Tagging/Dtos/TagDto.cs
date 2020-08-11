using System;
using Volo.Abp.Application.Dtos;

namespace KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos
{
    public class TagDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int UsageCount { get; set; }
    }
}