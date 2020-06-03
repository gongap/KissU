using System.Threading.Tasks;
using KissU.Common;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Application.Dtos;

[ServiceBundle("api/{Service}")]
public interface IPostService : IServiceKey
{
    [HttpGet(true)]
    [ServiceRoute("{blogId}/all")]
    Task<ListResult<PostWithDetailsDto>> GetListByBlogIdAndTagName(string blogId, string tagName);

    [HttpGet(true)]
    [ServiceRoute("{blogId}/all/by-time")]
    Task<ListResult<PostWithDetailsDto>> GetTimeOrderedListAsync(string blogId);

    [HttpPost(true)]
    [ServiceRoute("read")]
    Task<PostWithDetailsDto> GetForReadingAsync(GetPostInput input);

    [HttpGet(true)]
    [ServiceRoute("{id}")]
    Task<PostWithDetailsDto> GetAsync(string id);

    [HttpPost(true)]
    Task<PostWithDetailsDto> CreateAsync(CreatePostDto input);

    [HttpPut(true)]
    [ServiceRoute("{id}")]
    Task<PostWithDetailsDto> UpdateAsync(string id, UpdatePostDto input);

    [HttpDelete(true)]
    [ServiceRoute("{id}")]
    Task DeleteAsync(string id);
}