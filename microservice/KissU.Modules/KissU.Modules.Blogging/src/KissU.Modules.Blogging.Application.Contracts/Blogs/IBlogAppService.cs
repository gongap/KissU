using System;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Blogging.Application.Contracts.Blogs
{
    public interface IBlogAppService : IApplicationService
    {
        Task<ListResultDto<BlogDto>> GetListAsync();

        Task<BlogDto> GetByShortNameAsync(string shortName);

        Task<BlogDto> GetAsync(Guid id);
        
        Task<BlogDto> Create(CreateBlogDto input);

        Task<BlogDto> Update(Guid id, UpdateBlogDto input);

        Task Delete(Guid id);
    }
}
