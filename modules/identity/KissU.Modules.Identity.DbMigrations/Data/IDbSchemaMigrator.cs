﻿using System.Threading.Tasks;

namespace KissU.Modules.Identity.DbMigrations.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
