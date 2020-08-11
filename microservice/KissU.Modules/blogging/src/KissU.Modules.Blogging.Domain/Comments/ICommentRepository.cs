using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace KissU.Modules.Blogging.Domain.Comments
{
    public interface ICommentRepository : IBasicRepository<Comment, Guid>
    {
        Task<List<Comment>> GetListOfPostAsync(
            Guid postId
        );

        Task<int> GetCommentCountOfPostAsync(Guid postId);

        Task<List<Comment>> GetRepliesOfComment(Guid id);

        Task DeleteOfPost(Guid id);
    }
}
