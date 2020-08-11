using System;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using Volo.Abp.Application.Dtos;

namespace KissU.Modules.Blogging.Application.Contracts.Comments.Dtos
{
    public class CommentWithDetailsDto : FullAuditedEntityDto<Guid>
    {
        public Guid? RepliedCommentId { get; set; }

        public string Text { get; set; }

        public BlogUserDto Writer { get; set; }
    }
}
