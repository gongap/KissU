using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Blogs;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Application.Contracts.Tagging;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using KissU.Modules.Blogging.Web.Pages.Blogs.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace KissU.Modules.Blogging.Web.Pages.Blogs.Posts
{
    public class IndexModel : BloggingPageModel
    {
        private readonly IPostAppService _postAppService;
        private readonly IBlogAppService _blogAppService;
        private readonly ITagAppService _tagAppService;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TagName { get; set; }

        public BlogDto Blog { get; set; }

        public IReadOnlyList<PostWithDetailsDto> Posts { get; set; }

        public IReadOnlyList<TagDto> PopularTags { get; set; }

        public IndexModel(IPostAppService postAppService, IBlogAppService blogAppService, ITagAppService tagAppService)
        {
            _postAppService = postAppService;
            _blogAppService = blogAppService;
            _tagAppService = tagAppService;
        }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            if (BlogNameControlHelper.IsProhibitedFileFormatName(BlogShortName))
            {
                return NotFound();
            }

            Blog = await _blogAppService.GetByShortNameAsync(BlogShortName);
            Posts = (await _postAppService.GetListByBlogIdAndTagName(Blog.Id, TagName)).Items;
            PopularTags = (await _tagAppService.GetPopularTags(Blog.Id, new GetPopularTagsInput {ResultCount = 10, MinimumPostCount = 2}));

            return Page();
        }
    }
}