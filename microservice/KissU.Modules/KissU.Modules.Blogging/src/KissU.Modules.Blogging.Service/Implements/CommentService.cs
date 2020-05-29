using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Extensions;
using KissU.Surging.ProxyGenerator;
using Volo.Blogging.Comments;
using Volo.Blogging.Comments.Dtos;

namespace Volo.Blogging
{
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
