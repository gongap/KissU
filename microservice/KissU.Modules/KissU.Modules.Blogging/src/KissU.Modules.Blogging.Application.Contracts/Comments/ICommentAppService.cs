using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Blogging.Application.Contracts.Comments
{
    public interface ICommentAppService : IApplicationService
    {
        Task<List<CommentWithRepliesDto>> GetHierarchicalListOfPostAsync(Guid postId);

        Task<CommentWithDetailsDto> CreateAsync(CreateCommentDto input);

        Task<CommentWithDetailsDto> UpdateAsync(Guid id, UpdateCommentDto input);

        Task DeleteAsync(Guid id);
    }
}
