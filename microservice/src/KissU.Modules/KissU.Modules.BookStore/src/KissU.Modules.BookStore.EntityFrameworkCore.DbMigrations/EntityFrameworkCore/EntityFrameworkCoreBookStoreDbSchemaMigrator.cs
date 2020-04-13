using System.Threading.Tasks;
using KissU.Modules.BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.BookStore.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreBookStoreDbSchemaMigrator 
        : IBookStoreDbSchemaMigrator, ITransientDependency
    {
        private readonly BookStoreMigrationsDbContext _dbContext;

        public EntityFrameworkCoreBookStoreDbSchemaMigrator(BookStoreMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}