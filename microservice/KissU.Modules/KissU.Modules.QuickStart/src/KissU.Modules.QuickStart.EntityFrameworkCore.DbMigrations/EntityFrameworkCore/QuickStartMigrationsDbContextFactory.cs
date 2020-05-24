using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class QuickStartMigrationsDbContextFactory : IDesignTimeDbContextFactory<QuickStartMigrationsDbContext>
    {
        public QuickStartMigrationsDbContext CreateDbContext(string[] args)
        {
            QuickStartEfCoreEntityExtensionMappings.Configure();
            
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<QuickStartMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new QuickStartMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
