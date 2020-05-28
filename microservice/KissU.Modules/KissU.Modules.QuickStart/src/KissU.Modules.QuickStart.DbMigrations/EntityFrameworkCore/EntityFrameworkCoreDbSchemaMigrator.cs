using System.Threading.Tasks;
using KissU.Modules.QuickStart.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreDbSchemaMigrator 
        : IQuickStartDbSchemaMigrator, ITransientDependency
    {
        private readonly MigrationsDbContext _dbContext;

        public EntityFrameworkCoreDbSchemaMigrator(MigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}