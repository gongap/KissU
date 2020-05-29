using System.Threading.Tasks;
using KissU.Core.Common;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Blogging.Blogs.Dtos;

namespace Volo.Blogging
{
      [ServiceBundle("api/{Service}")]
    public interface IBlogService : IServiceKey
    {
        [HttpGet(true)]
        Task<ListResult<BlogDto>> GetListAsync();

        [HttpGet(true)]
        [ServiceRoute("by-shortname/{shortName}")]
        Task<BlogDto> GetByShortNameAsync(string shortName);

        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<BlogDto> GetAsync(string id);

        [HttpPost(true)]
        Task<BlogDto> Create(CreateBlogDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<BlogDto> Update(string id, UpdateBlogDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task Delete(string id);
    }
}
