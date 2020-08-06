using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Models;
using KissU.Modules.Blogging.Application.Contracts.Blogs;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ProxyGenerator;

namespace KissU.Modules.Blogging.Service.Implements
{
    [ModuleName("Blog")]
    public class BlogService : ProxyServiceBase, IBlogService
    {
        private readonly IBlogAppService _blogAppService;

        public BlogService(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        public async Task<ListResult<BlogDto>> GetListAsync()
        {
            var result = await _blogAppService.GetListAsync();
            return new ListResult<BlogDto>(result.Items);
        }

        public async Task<BlogDto> GetByShortNameAsync(string shortName)
        {
            return await _blogAppService.GetByShortNameAsync(shortName);
        }

        public async Task<BlogDto> GetAsync(string id)
        {
            return await _blogAppService.GetAsync(id.ToGuid());
        }

        public async Task<BlogDto> Create(CreateBlogDto input)
        {
            return await _blogAppService.Create(input);
        }

        public async Task<BlogDto> Update(string id, UpdateBlogDto input)
        {
            return await _blogAppService.Update(id.ToGuid(), input);
        }

        public async Task Delete(string id)
        {
            await _blogAppService.Delete(id.ToGuid());
        }
    }
}
