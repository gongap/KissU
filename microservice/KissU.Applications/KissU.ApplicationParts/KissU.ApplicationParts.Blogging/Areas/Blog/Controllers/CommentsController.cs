using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.ProxyGenerator;
using Microsoft.AspNetCore.Mvc;

namespace KissU.ApplicationParts.Blogging.Areas.Blog.Controllers
{
    //TODO: Is that being used?

    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class CommentsController : BloggingControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(IServiceProxyFactory serviceProxyFactory)
        {
            _commentService = serviceProxyFactory.CreateProxy<ICommentService>();
        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            await _commentService.DeleteAsync(id.ToString());
        }

        [HttpPost]
        public async Task Update(Guid id, UpdateCommentDto commentDto)
        {
            await _commentService.UpdateAsync(id.ToString(), commentDto);
        }
    }
}
