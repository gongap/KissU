using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace KissU.Modules.QuickStart.Books
{
    public class BookDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAsyncQueryableExecuter _queryableExecuter;

        public BookDataSeedContributor(
            IRepository<Book, Guid> bookRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter)
        {
            _bookRepository = bookRepository;
            _queryableExecuter = asyncQueryableExecuter;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _queryableExecuter.CountAsync(_bookRepository) > 0)
            {
                return;
            }

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Pet Sematary",
                    Price = 42,
                    PublishDate = new DateTime(1995, 11, 15),
                    Type = BookType.Horror
                }
            );
        }
    }
}
