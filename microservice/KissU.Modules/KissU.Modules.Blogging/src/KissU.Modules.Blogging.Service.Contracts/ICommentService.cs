using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Blogging.Comments.Dtos;

namespace Volo.Blogging
{
    [ServiceBundle("api/{Service}")]
    public interface ICommentService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("hierarchical/{postId}")]
        Task<List<CommentWithRepliesDto>> GetHierarchicalListOfPostAsync(string postId);

        [HttpPost(true)]
        Task<CommentWithDetailsDto> CreateAsync(CreateCommentDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<CommentWithDetailsDto> UpdateAsync(string id, UpdateCommentDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task DeleteAsync(string id);
    }
}
