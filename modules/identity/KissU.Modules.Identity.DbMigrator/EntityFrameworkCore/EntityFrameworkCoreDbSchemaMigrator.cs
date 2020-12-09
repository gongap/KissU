﻿using System.Threading.Tasks;
using KissU.Modules.Identity.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.Identity.DbMigrator.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreDbSchemaMigrator : IDbSchemaMigrator, ITransientDependency
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