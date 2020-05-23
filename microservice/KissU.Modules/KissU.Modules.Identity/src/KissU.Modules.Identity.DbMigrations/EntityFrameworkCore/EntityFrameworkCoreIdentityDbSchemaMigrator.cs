using System.Threading.Tasks;
using KissU.Modules.Identity.DbMigrations.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.Identity.DbMigrations.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreIdentityDbSchemaMigrator : IIdentityDbSchemaMigrator, ITransientDependency
    {
        private readonly IdentityMigrationsDbContext _dbContext;

        public EntityFrameworkCoreIdentityDbSchemaMigrator(IdentityMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}