using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Posts;
using Microsoft.AspNetCore.Mvc;

namespace KissU.Modules.Blogging.Web.Areas.Blog.Controllers
{
    //TODO: Is that being used?

    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class PostsController : BloggingControllerBase
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            await _postAppService.DeleteAsync(id);
        }
    }
}
