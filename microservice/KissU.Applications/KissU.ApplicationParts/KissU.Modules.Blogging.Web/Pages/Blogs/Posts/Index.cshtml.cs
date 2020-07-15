using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Blogs;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Application.Contracts.Tagging;
using KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.Modules.Blogging.Web.Pages.Blogs.Shared.Helpers;
using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Mvc;

namespace KissU.Modules.Blogging.Web.Pages.Blogs.Posts
{
    public class IndexModel : BloggingPageModel
    {
        private readonly IPostService _postService;
        private readonly IBlogService _blogService;
        private readonly ITagService _tagService;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TagName { get; set; }

        public BlogDto Blog { get; set; }

        public IReadOnlyList<PostWithDetailsDto> Posts { get; set; }

        public IReadOnlyList<TagDto> PopularTags { get; set; }

        public IndexModel(IServiceProxyFactory serviceProxyFactory)
        {
            _postService = serviceProxyFactory.CreateProxy<IPostService>();
            _blogService = serviceProxyFactory.CreateProxy<IBlogService>();
            _tagService = serviceProxyFactory.CreateProxy<ITagService>();
        }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            if (BlogNameControlHelper.IsProhibitedFileFormatName(BlogShortName))
            {
                return NotFound();
            }

            Blog = await _blogService.GetByShortNameAsync(BlogShortName);
            Posts = (await _postService.GetListByBlogIdAndTagName(Blog.Id.ToString(), TagName)).Items;
            PopularTags = (await _tagService.GetPopularTags(Blog.Id.ToString(), new GetPopularTagsInput {ResultCount = 10, MinimumPostCount = 2}));

            return Page();
        }
    }
}