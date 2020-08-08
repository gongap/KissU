using System;

namespace KissU.Modules.Blogging.Application.Contracts.Comments.Dtos
{
    public class CreateCommentDto
    {
        public Guid? RepliedCommentId { get; set; }

        public Guid PostId { get; set; }

        public string Text { get; set; }
    }
}