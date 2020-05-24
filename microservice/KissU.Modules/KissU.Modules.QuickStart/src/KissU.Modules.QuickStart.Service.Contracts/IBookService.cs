using System;
using System.Threading.Tasks;
using KissU.Core.Common.Application.Dtos;
using KissU.Core.Dependency;
using KissU.Modules.QuickStart.Books;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Application.Dtos;

namespace KissU.Modules.QuickStart.Service
{
    [ServiceBundle("api/{Service}")]
    public interface IBookService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<BookDto> GetAsync(Guid id);

        [HttpPost(true)]
        Task<PagedResult<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [HttpPost(true)]
        Task<BookDto> CreateAsync(CreateUpdateBookDto input);

        [HttpPut(true)]
        [ServiceRoute("{id}")]
        Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input);

        [HttpDelete(true)]
        [ServiceRoute("{id}")]
        Task DeleteAsync(Guid id);
    }
}