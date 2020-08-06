using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ProxyGenerator;
using Microsoft.AspNetCore.Mvc;

namespace KissU.ApplicationParts.Blogging.Areas.Blog.Controllers
{
    //TODO: Is that being used?

    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class PostsController : BloggingControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IServiceProxyFactory serviceProxyFactory)
        {
            _postService = serviceProxyFactory.CreateProxy<IPostService>();
        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            await _postService.DeleteAsync(id.ToString());
        }
    }
}
