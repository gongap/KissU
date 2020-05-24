using System.Threading.Tasks;
using KissU.Modules.QuickStart.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreQuickStartDbSchemaMigrator 
        : IQuickStartDbSchemaMigrator, ITransientDependency
    {
        private readonly QuickStartMigrationsDbContext _dbContext;

        public EntityFrameworkCoreQuickStartDbSchemaMigrator(QuickStartMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}