﻿using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Models;

namespace KissU.Modules.Blogging.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IBlogService : IServiceKey
    {
        [HttpGet(true)]
        Task<ListResult<BlogDto>> GetListAsync();

        [HttpGet(true)]
        [ServiceRoute("by-shortname/{shortName}")]
        Task<BlogDto> GetByShortNameAsync(string shortName);

        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<BlogDto> GetAsync(string id);

        [HttpPost(true)]
        Task<BlogDto> Create(CreateBlogDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<BlogDto> Update(string id, UpdateBlogDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task Delete(string id);
    }
}