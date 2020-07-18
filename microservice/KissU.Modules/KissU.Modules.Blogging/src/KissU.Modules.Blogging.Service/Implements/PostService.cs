using System.Threading.Tasks;
using KissU.Common;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Services.Blogging.Contract;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Blogging.Service.Implements
{
    [ModuleName("Post")]
    public class PostService : ProxyServiceBase, IPostService
    {
        private readonly IPostAppService _postAppService;

        public PostService(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public async Task<ListResult<PostWithDetailsDto>> GetListByBlogIdAndTagName(string blogId, string tagName)
        {
            var result = await _postAppService.GetListByBlogIdAndTagName(blogId.ToGuid(), tagName);
            return new ListResult<PostWithDetailsDto>(result.Items);
        }

        public async Task<ListResult<PostWithDetailsDto>> GetTimeOrderedListAsync(string blogId)
        {
            var result = await _postAppService.GetTimeOrderedListAsync(blogId.ToGuid());
            return new ListResult<PostWithDetailsDto>(result.Items);
        }

        public Task<PostWithDetailsDto> GetForReadingAsync(GetPostInput input)
        {
            return _postAppService.GetForReadingAsync(input);
        }

        public Task<PostWithDetailsDto> GetAsync(string id)
        {
            return _postAppService.GetAsync(id.ToGuid());
        }

        public Task<PostWithDetailsDto> CreateAsync(CreatePostDto input)
        {
            return _postAppService.CreateAsync(input);
        }

        public Task<PostWithDetailsDto> UpdateAsync(string id, UpdatePostDto input)
        {
            return _postAppService.UpdateAsync(id.ToGuid(), input);
        }

        public Task DeleteAsync(string id)
        {
            return _postAppService.DeleteAsync(id.ToGuid());
        }
    }
}
