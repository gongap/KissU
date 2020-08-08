using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modules.Blogging.Application.Contracts.Tagging;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Blogging.Service.Implements
{
    [ModuleName("Tag")]
    public class TagService : ProxyServiceBase, ITagService
    {
        private readonly ITagAppService _tagAppService;

        public TagService(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public Task<List<TagDto>> GetPopularTags(string blogId, GetPopularTagsInput input)
        {
            return _tagAppService.GetPopularTags(blogId.ToGuid(), input);
        }
    }
}
