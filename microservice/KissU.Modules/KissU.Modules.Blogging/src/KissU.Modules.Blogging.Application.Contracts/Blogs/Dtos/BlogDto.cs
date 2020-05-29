using System;
using Volo.Abp.Application.Dtos;

namespace KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos
{
    public class BlogDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }
    }
}