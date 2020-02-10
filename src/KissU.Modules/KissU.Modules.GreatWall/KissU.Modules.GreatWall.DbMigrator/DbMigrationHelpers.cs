using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.GreatWall.DbMigrator
{
    /// <summary>
    /// DbMigrationHelpers.
    /// </summary>
    internal static class DbMigrationHelpers
    {
        /// <summary>
        /// Builds the configuration.
        /// </summary>
        /// <returns>IConfigurationRoot.</returns>
        public static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            return builder.Build();
        }

        /// <summary>
        /// migrate as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="services">The services.</param>
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

        /// <summary>
        /// Ensures the databases migrated.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
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

        /// <summary>
        /// Ensures the seed data.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        public static async Task EnsureSeedData<TDbContext>(IServiceProvider serviceProvider)
            where TDbContext : DbContext
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<TDbContext>())
                {
                    await EnsureSeedData(scope.ServiceProvider);
                    await context.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Ensures the seed data.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            var userMgr = serviceProvider.GetRequiredService<UserManager<User>>();
            var alice = await userMgr.FindByNameAsync("alice").ConfigureAwait(false);
            if (alice == null)
            {
                alice = new User
                {
                    UserName = "alice",
                    Enabled = true
                };
                var result = await userMgr.CreateAsync(alice, "Pass123$").ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                //result = await userMgr.AddClaimsAsync(alice, new Claim[]{
                //        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                //        new Claim(JwtClaimTypes.GivenName, "Alice"),
                //        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                //        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                //        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                //        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                //        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", "json")
                //    }).ConfigureAwait(false);
                //if (!result.Succeeded)
                //{
                //    throw new Exception(result.Errors.First().Description);
                //}
                Console.WriteLine("alice created");
            }
            else
            {
                Console.WriteLine("alice already exists");
            }

            var bob = await userMgr.FindByNameAsync("bob").ConfigureAwait(false);
            if (bob == null)
            {
                bob = new User
                {
                    UserName = "bob",
                    Enabled = true
                };
                var result = await userMgr.CreateAsync(bob, "Pass123$").ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                //result = await userMgr.AddClaimsAsync(bob, new Claim[]{
                //        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                //        new Claim(JwtClaimTypes.GivenName, "Bob"),
                //        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                //        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                //        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                //        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                //        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", "json"),
                //        new Claim("location", "somewhere")
                //    }).ConfigureAwait(false);
                //if (!result.Succeeded)
                //{
                //    throw new Exception(result.Errors.First().Description);
                //}
                Console.WriteLine("bob created");
            }
            else
            {
                Console.WriteLine("bob already exists");
            }
        }
    }
}