using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Blogging.Tagging.Dtos;

namespace Volo.Blogging
{
    [ServiceBundle("api/{Service}")]
    public interface ITagService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("popular/{blogId}")]
        Task<List<TagDto>> GetPopularTags(string blogId, GetPopularTagsInput input);
    }
}
