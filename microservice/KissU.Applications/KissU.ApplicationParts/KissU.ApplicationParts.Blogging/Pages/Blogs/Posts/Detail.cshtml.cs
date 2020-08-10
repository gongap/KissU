using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using KissU.ApplicationParts.Blogging.Pages.Blogs.Shared.Helpers;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ServiceProxy;
using Microsoft.AspNetCore.Mvc;

namespace KissU.ApplicationParts.Blogging.Pages.Blogs.Posts
{
    public class DetailModel : BloggingPageModel
    {
        private const int TwitterLinkLength = 23;
        private readonly IPostService _postService;
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PostUrl { get; set; }

        [BindProperty]
        public PostDetailsViewModel NewComment { get; set; }

        public int CommentCount { get; set; }

        [HiddenInput]
        public Guid FocusCommentId { get; set; }

        public PostWithDetailsDto Post { get; set; }

        public IReadOnlyList<CommentWithRepliesDto> CommentsWithReplies { get; set; }

        public BlogDto Blog { get; set; }

        public DetailModel(IServiceProxyFactory serviceProxyFactory)
        {
            _postService = serviceProxyFactory.CreateProxy<IPostService>();
            _blogService = serviceProxyFactory.CreateProxy<IBlogService>();
            _commentService = serviceProxyFactory.CreateProxy<ICommentService>();
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            if (BlogNameControlHelper.IsProhibitedFileFormatName(BlogShortName))
            {
                return NotFound();
            }

            await GetData();

            return Page();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var comment = await _commentService.CreateAsync(new CreateCommentDto()
            {
                RepliedCommentId = NewComment.RepliedCommentId,
                PostId = NewComment.PostId,
                Text = NewComment.Text
            });

            FocusCommentId = comment.Id;

            await GetData();

            return Page();
        }

        private async Task GetData()
        {
            Blog = await _blogService.GetByShortNameAsync(BlogShortName);
            Post = await _postService.GetForReadingAsync(new GetPostInput { BlogId = Blog.Id, Url = PostUrl });
            CommentsWithReplies = await _commentService.GetHierarchicalListOfPostAsync(Post.Id.ToString());
            CountComments();
        }

        public void CountComments()
        {
            CommentCount = CommentsWithReplies.Count;
            foreach (var commentWithReply in CommentsWithReplies)
            {
                CommentCount += commentWithReply.Replies.Count;
            }
        }

        public string GetTwitterShareUrl(string title, string url, string linkedAccounts)
        {
            var readAtString = " | Read More At ";
            var otherCharsLength = (readAtString + linkedAccounts).Length + 1;
            var maxTitleLength = 280 - TwitterLinkLength - otherCharsLength;
            title = title.Length < maxTitleLength ? title : title.Substring(0, maxTitleLength - 3) + "...";

            var text = title +
                       readAtString +
                       url +
                       " " + linkedAccounts;

            return (new UriBuilder("https://twitter.com/intent/tweet") { Query = "text=" + HttpUtility.UrlEncode(text) }).ToString();
        }

        public class PostDetailsViewModel
        {
            public Guid? RepliedCommentId { get; set; }

            public Guid PostId { get; set; }

            public string Text { get; set; }
        }
    }
}