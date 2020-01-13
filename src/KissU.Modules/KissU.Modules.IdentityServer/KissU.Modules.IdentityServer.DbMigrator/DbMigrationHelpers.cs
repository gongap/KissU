using System;
using System.IO;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.IdentityServer.DbMigrator
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
                using (var context = scope.ServiceProvider.GetRequiredService<TDbContext>())
                {
                    EnsureSeedData(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static void EnsureSeedData(DbContext context)
        {
            Console.WriteLine("Seeding database...");

            if (!context.Set<Client>().Any())
            {
                Console.WriteLine("Clients being populated");
                foreach (var client in Config.Clients)
                {
                    context.Set<Client>().Add(client.MapTo<Client>());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Clients already populated");
            }

            if (!context.Set<IdentityResource>().Any())
            {
                Console.WriteLine("IdentityResources being populated");
                foreach (var resource in Config.IdentityResources)
                {
                    context.Set<IdentityResource>().Add(resource.MapTo<IdentityResource>());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!context.Set<ApiResource>().Any())
            {
                Console.WriteLine("ApiResources being populated");
                foreach (var resource in Config.ApiResources)
                {
                    context.Set<ApiResource>().Add(resource.MapTo<ApiResource>());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}