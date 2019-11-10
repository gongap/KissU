using KissU.Modules.Theme.Data.UnitOfWorks.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.Theme.Data.DbMigrations
{
    /// <summary>
    /// This DbContext is only used for database migrations.
    /// </summary>
    public class MigrationsDbContext : ThemeUnitOfWork
    {
        /// <summary>
        ///  Initializes a new instance of the DbContext.
        ///  The method will be called to configure the database (and other options) to be used for this context.
        /// </summary>
        public MigrationsDbContext(DbContextOptions options) : base(options) { }
    }
}
