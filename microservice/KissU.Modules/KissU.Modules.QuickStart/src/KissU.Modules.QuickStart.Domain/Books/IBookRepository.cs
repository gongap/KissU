using System;
using Volo.Abp.Domain.Repositories;

namespace KissU.Modules.QuickStart.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
    }
}
