using AutoMapper;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using Volo.Abp.AutoMapper;
using Volo.Blogging.Pages.Blog.Posts;

namespace Volo.Blogging
{
    public class AbpBloggingWebAutoMapperProfile : Profile
    {
        public AbpBloggingWebAutoMapperProfile()
        {
            CreateMap<PostWithDetailsDto, EditPostViewModel>().Ignore(x=>x.Tags);
            CreateMap<NewModel.CreatePostViewModel, CreatePostDto>();
        }
    }
}
