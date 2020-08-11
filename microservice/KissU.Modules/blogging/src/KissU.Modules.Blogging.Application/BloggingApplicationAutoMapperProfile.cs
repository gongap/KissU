using AutoMapper;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using KissU.Modules.Blogging.Domain.Blogs;
using KissU.Modules.Blogging.Domain.Comments;
using KissU.Modules.Blogging.Domain.Posts;
using KissU.Modules.Blogging.Domain.Tagging;
using KissU.Modules.Blogging.Domain.Users;
using Volo.Abp.AutoMapper;

namespace KissU.Modules.Blogging.Application
{
    public class BloggingApplicationAutoMapperProfile : Profile
    {
        public BloggingApplicationAutoMapperProfile()
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogUser, BlogUserDto>();
            CreateMap<Post, PostWithDetailsDto>().Ignore(x=>x.Writer).Ignore(x=>x.CommentCount).Ignore(x=>x.Tags);
            CreateMap<Comment, CommentWithDetailsDto>().Ignore(x => x.Writer);
            CreateMap<Tag, TagDto>();
        }
    }
}
