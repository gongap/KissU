using System.Collections.Generic;

namespace KissU.Modules.Blogging.Application.Contracts.Comments.Dtos
{
    public class CommentWithRepliesDto
    {
        public CommentWithDetailsDto Comment { get; set; }

        public List<CommentWithDetailsDto> Replies { get; set; } = new List<CommentWithDetailsDto>();
    }
}
