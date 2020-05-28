using System;
using System.Threading.Tasks;
using KissU.Core.Common;
using KissU.Core.Dependency;
using KissU.Core.Extensions;
using KissU.Modules.QuickStart.Books;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Application.Dtos;

namespace KissU.Modules.QuickStart.Service.Implements
{
    [ModuleName("Book")]
    public class BookService : ProxyServiceBase, IBookService
    {
        private readonly IBookAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public BookService(IBookAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        public Task<BookDto> GetAsync(string id)
        {
            return _appService.GetAsync(id.ToGuid());
        }

        public async Task<PagedResult<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await _appService.GetListAsync(input);
            return new PagedResult<BookDto>(result.TotalCount, result.Items);
        }

        public Task<BookDto> CreateAsync(CreateUpdateBookDto input)
        {
            return _appService.CreateAsync(input);
        }

        public Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            return _appService.UpdateAsync(id, input);
        }

        public virtual Task DeleteAsync(string id)
        {
            return _appService.DeleteAsync(id.ToGuid());
        }
    }
}