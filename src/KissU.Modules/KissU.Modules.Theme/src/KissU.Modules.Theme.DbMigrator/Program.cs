using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util;

namespace KissU.Modules.Theme.DbMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();
                services.AddUtil();
                await MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task MigrateAsync()
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<DesignTimeDbContext>().UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var database = new DesignTimeDbContext(builder.Options).Database;
            Console.WriteLine(@"Started database migrations...");

            Console.WriteLine(@"Migrating database schema...");
            await database.MigrateAsync();

            Console.WriteLine(@"Executing database seed...");
            //await _dataSeeder.SeedAsync();

            Console.WriteLine(@"Successfully completed database migrations.");
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
