using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KissU.ApplicationParts.Blogging.Pages.Blogs.Shared.Helpers;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Application.Contracts.Shared;
using KissU.Modules.Blogging.Domain.Shared.Posts;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ServiceProxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Validation;

namespace KissU.ApplicationParts.Blogging.Pages.Blogs.Posts
{
    public class EditModel : BloggingPageModel
    {
        private readonly IPostService _postService;
        private readonly IBlogService _blogService;
        private readonly IAuthorizationService _authorization;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PostId { get; set; }

        [BindProperty]
        public EditPostViewModel Post { get; set; }

        public EditModel(IServiceProxyFactory serviceProxyFactory, IAuthorizationService authorization)
        {
            _postService = serviceProxyFactory.CreateProxy<IPostService>();
            _blogService = serviceProxyFactory.CreateProxy<IBlogService>();
            _authorization = authorization;
        }


        public virtual async Task<ActionResult> OnGetAsync()
        {
            if (!await _authorization.IsGrantedAsync(BloggingPermissions.Posts.Update))
            {
                return Redirect("/");
            }
            if (BlogNameControlHelper.IsProhibitedFileFormatName(BlogShortName))
            {
                return NotFound();
            }

            var postDto = await _postService.GetAsync(PostId);
            Post = ObjectMapper.Map<PostWithDetailsDto, EditPostViewModel>(postDto);
            Post.Tags = String.Join(", ", postDto.Tags.Select(p => p.Name).ToArray());

            return Page();
        }

        public virtual async Task<ActionResult> OnPostAsync()
        {
            var post = new UpdatePostDto
            {
                BlogId = Post.BlogId,
                Title = Post.Title,
                Url = Post.Url,
                CoverImage = Post.CoverImage,
                Content = Post.Content,
                Tags = Post.Tags,
                Description = Post.Description.IsNullOrEmpty() ?
                    Post.Content.Truncate(PostConsts.MaxSeoFriendlyDescriptionLength) :
                    Post.Description
            };

            var editedPost = await _postService.UpdateAsync(Post.Id.ToString(), post);
            var blog = await _blogService.GetAsync(editedPost.BlogId.ToString());

            return RedirectToPage("/Blogs/Posts/Detail", new { blogShortName = blog.ShortName, postUrl = editedPost.Url });
        }
    }

    public class EditPostViewModel
    {
        [Required]
        [HiddenInput]
        public Guid Id { get; set; }

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

        [DynamicStringLength(typeof(PostConsts), nameof(PostConsts.MaxDescriptionLength))]
        public string Description { get; set; }

        public string Tags { get; set; }
    }
}