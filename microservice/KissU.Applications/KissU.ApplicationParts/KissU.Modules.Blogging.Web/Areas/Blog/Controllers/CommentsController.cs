﻿using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Comments;
using KissU.Modules.Blogging.Application.Contracts.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KissU.Modules.Blogging.Web.Areas.Blog.Controllers
{
    //TODO: Is that being used?

    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class CommentsController : BloggingControllerBase
    {
        private readonly ICommentAppService _commentAppService;

        public CommentsController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;

        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            await _commentAppService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Update(Guid id, UpdateCommentDto commentDto)
        {
            await _commentAppService.UpdateAsync(id, commentDto);
        }
    }
}
