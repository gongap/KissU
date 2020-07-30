using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modules.Blogging.Application.Contracts.Comments;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Blogging.Service.Implements
{
    [ModuleName("Comment")]
    public class CommentService : ProxyServiceBase, ICommentService
    {
        private readonly ICommentAppService _commentAppService;

        public CommentService(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        public Task<List<CommentWithRepliesDto>> GetHierarchicalListOfPostAsync(string postId)
        {
            return _commentAppService.GetHierarchicalListOfPostAsync(postId.ToGuid());
        }

        public Task<CommentWithDetailsDto> CreateAsync(CreateCommentDto input)
        {
            return _commentAppService.CreateAsync(input);
        }

        public Task<CommentWithDetailsDto> UpdateAsync(string id, UpdateCommentDto input)
        {
            return _commentAppService.UpdateAsync(id.ToGuid(), input);
        }

        public Task DeleteAsync(string id)
        {
            return _commentAppService.DeleteAsync(id.ToGuid());
        }
    }
}
