using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Blogging.Application.Contracts.Tagging
{
    public interface ITagAppService : IApplicationService
    {
        Task<List<TagDto>> GetPopularTags(Guid blogId, GetPopularTagsInput input);

    }
}
