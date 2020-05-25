using System;
using KissU.Modules.QuickStart.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.QuickStart.Books
{
    public class BookRepository : EfCoreRepository<QuickStartDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<QuickStartDbContext> dbContextProvider, IServiceProvider serviceProvider)
            : base(dbContextProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}