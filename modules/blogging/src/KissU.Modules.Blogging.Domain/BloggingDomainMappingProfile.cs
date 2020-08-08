using AutoMapper;
using KissU.Modules.Blogging.Domain.Blogs;
using KissU.Modules.Blogging.Domain.Comments;
using KissU.Modules.Blogging.Domain.Posts;
using KissU.Modules.Blogging.Domain.Shared.Blogs;
using KissU.Modules.Blogging.Domain.Shared.Comments;
using KissU.Modules.Blogging.Domain.Shared.Posts;
using KissU.Modules.Blogging.Domain.Shared.Tagging;
using KissU.Modules.Blogging.Domain.Tagging;

namespace KissU.Modules.Blogging.Domain
{
    public class BloggingDomainMappingProfile : Profile
    {
        public BloggingDomainMappingProfile()
        {
            CreateMap<Blog, BlogEto>();
            CreateMap<Comment, CommentEto>();
            CreateMap<Post, PostEto>();
            CreateMap<Tag, TagEto>();
        }
    }
}