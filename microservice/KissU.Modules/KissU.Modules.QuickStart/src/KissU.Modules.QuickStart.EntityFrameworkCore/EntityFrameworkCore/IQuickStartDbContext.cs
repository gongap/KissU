using KissU.Modules.QuickStart.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    [ConnectionStringName(QuickStartDbProperties.ConnectionStringName)]
    public interface IQuickStartDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Book> Books { get; }
    }
}