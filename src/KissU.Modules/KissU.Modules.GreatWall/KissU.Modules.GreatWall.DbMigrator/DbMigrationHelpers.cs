using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.GreatWall.DbMigrator
{
    internal static class DbMigrationHelpers
    {
        public static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            return builder.Build();
        }

        public static async Task MigrateAsync<TDbContext>(IServiceProvider services)
            where TDbContext : DbContext
        {
            using (var serviceScope = services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                Console.WriteLine(@"Started database migrations...");
                Console.WriteLine(@"Migrating database schema...");
                await EnsureDatabasesMigrated<TDbContext>(serviceProvider);
                Console.WriteLine(@"Executing database seed...");
                await EnsureSeedData<TDbContext>(serviceProvider);
                Console.WriteLine(@"Successfully completed database migrations.");
            }
        }

        public static async Task EnsureDatabasesMigrated<TDbContext>(IServiceProvider serviceProvider)
            where TDbContext : DbContext
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<TDbContext>())
                {
                    await context.Database.MigrateAsync();
                }
            }
        }

        public static async Task EnsureSeedData<TDbContext>(IServiceProvider serviceProvider)
            where TDbContext : DbContext
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TDbContext>();

                await context.SaveChangesAsync();
            }
        }
    }
}