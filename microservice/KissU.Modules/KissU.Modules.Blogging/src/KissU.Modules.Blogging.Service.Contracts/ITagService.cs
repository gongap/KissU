using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.Blogging.Contract
{
    [ServiceBundle("api/{Service}")]
    public interface ITagService : IServiceKey
    {
        [HttpPost(true)]
        [ServiceRoute("popular/{blogId}")]
        Task<List<TagDto>> GetPopularTags(string blogId, GetPopularTagsInput input);
    }
}