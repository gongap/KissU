using AutoMapper;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Web.Pages.Blogs.Posts;
using Volo.Abp.AutoMapper;

namespace KissU.Modules.Blogging.Web
{
    public class AbpBloggingWebAutoMapperProfile : Profile
    {
        public AbpBloggingWebAutoMapperProfile()
        {
            //CreateMap<PostWithDetailsDto, EditPostViewModel>().Ignore(x => x.Tags);
            //CreateMap<NewModel.CreatePostViewModel, CreatePostDto>();
        }
    }
}
