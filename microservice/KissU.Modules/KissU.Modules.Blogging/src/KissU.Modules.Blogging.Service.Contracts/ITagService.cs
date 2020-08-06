﻿using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Blogging.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface ITagService : IServiceKey
    {
        [HttpPost(true)]
        [ServiceRoute("popular/{blogId}")]
        Task<List<TagDto>> GetPopularTags(string blogId, GetPopularTagsInput input);
    }
}