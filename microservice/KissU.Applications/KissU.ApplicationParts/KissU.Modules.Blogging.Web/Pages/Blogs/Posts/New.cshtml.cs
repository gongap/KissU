using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Domain.Shared.Posts;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.Modules.Blogging.Web.Pages.Blogs.Shared.Helpers;
using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.Validation;

namespace KissU.Modules.Blogging.Web.Pages.Blogs.Posts
{
    public class NewModel : BloggingPageModel
    {
        private readonly IPostService _postService;
        private readonly IBlogService _blogService;
        private readonly IAuthorizationService _authorization;
        private readonly BloggingUrlOptions _blogOptions;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty]
        public CreatePostViewModel Post { get; set; }

        public BlogDto Blog { get; set; }

        public NewModel(IServiceProxyFactory serviceProxyFactory, IAuthorizationService authorization, IOptions<BloggingUrlOptions> blogOptions)
        {
            _postService = serviceProxyFactory.CreateProxy<IPostService>();
            _blogService = serviceProxyFactory.CreateProxy<IBlogService>();
            _authorization = authorization;
            _blogOptions = blogOptions.Value;
        }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            if (!await _authorization.IsGrantedAsync(BloggingPermissions.Posts.Create))
            {
                return Redirect("/");
            }
            if (BlogNameControlHelper.IsProhibitedFileFormatName(BlogShortName))
            {
                return NotFound();
            }

            Blog = await _blogService.GetByShortNameAsync(BlogShortName);
            Post = new CreatePostViewModel
            {
                BlogId = Blog.Id
            };

            return Page();
        }

        public virtual async Task<ActionResult> OnPost()
        {
            var blog = await _blogService.GetAsync(Post.BlogId.ToString());

            if (string.IsNullOrEmpty(Post.Description))
            {
                Post.Description = Post.Content.Truncate(PostConsts.MaxSeoFriendlyDescriptionLength);
            }

            var postWithDetailsDto = await _postService.CreateAsync(ObjectMapper.Map<CreatePostViewModel, CreatePostDto>(Post));

            //TODO: Try Url.Page(...)
            var urlPrefix = _blogOptions.RoutePrefix;
            return Redirect(Url.Content($"~{urlPrefix}{WebUtility.UrlEncode(blog.ShortName)}/{WebUtility.UrlEncode(postWithDetailsDto.Url)}"));
        }

        public class CreatePostViewModel
        {
            [Required]
            [HiddenInput]
            public Guid BlogId { get; set; }

            [Required]
            [DynamicStringLength(typeof(PostConsts), nameof(PostConsts.MaxTitleLength))]
            public string Title { get; set; }

            [Required]
            [HiddenInput]
            public string CoverImage { get; set; }

            [Required]
            [DynamicStringLength(typeof(PostConsts), nameof(PostConsts.MaxUrlLength))]
            public string Url { get; set; }

            [HiddenInput]
            [DynamicStringLength(typeof(PostConsts), nameof(PostConsts.MaxContentLength))]
            public string Content { get; set; }

            public string Tags { get; set; }

            [DynamicStringLength(typeof(PostConsts), nameof(PostConsts.MaxDescriptionLength))]
            public string Description { get; set; }

        }
    }
}