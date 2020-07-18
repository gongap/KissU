using AutoMapper;
using KissU.ApplicationParts.Blogging.Pages.Blogs.Posts;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using Volo.Abp.AutoMapper;

namespace KissU.ApplicationParts.Blogging
{
    public class AbpBloggingWebAutoMapperProfile : Profile
    {
        public AbpBloggingWebAutoMapperProfile()
        {
            CreateMap<PostWithDetailsDto, EditPostViewModel>().Ignore(x => x.Tags);
            CreateMap<NewModel.CreatePostViewModel, CreatePostDto>();
        }
    }
}
