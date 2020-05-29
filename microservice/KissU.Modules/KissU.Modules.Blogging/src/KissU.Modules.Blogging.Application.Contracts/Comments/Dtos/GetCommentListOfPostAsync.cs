using System;

namespace KissU.Modules.Blogging.Application.Contracts.Comments.Dtos
{
    public class GetCommentListOfPostAsync
    {
        public Guid PostId { get; set; }
    }
}