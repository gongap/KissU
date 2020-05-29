using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.Extensions;
using KissU.Surging.ProxyGenerator;
using Volo.Blogging.Tagging;
using Volo.Blogging.Tagging.Dtos;

namespace Volo.Blogging
{
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
