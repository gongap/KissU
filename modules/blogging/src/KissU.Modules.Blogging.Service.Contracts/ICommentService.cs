using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Blogging.Service.Contracts
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