using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Util.Helpers;

namespace KissU.Modules.Theme.Data.DbMigrations
{
    /// <summary>
    /// This class is needed for EF Core console commands
    /// (like Add-Migration and Update-Database commands)
    /// </summary>
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<MigrationsDbContext>
    {
        /// <summary>Creates a new instance of a derived context.</summary>
        /// <param name="args"> Arguments provided by the design-time service. </param>
        /// <returns> An instance of DbContext. </returns>
        public MigrationsDbContext CreateDbContext(string[] args)
        {
            Ioc.Register();
            var builder = new DbContextOptionsBuilder().UseSqlServer(@"Server=.;Database=KissU;uid=sa;pwd=saP@ss123;MultipleActiveResultSets=true");
            return new MigrationsDbContext(builder.Options);
        }
    }
}
