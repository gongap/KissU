using System;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Domain;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Datas.SqlServer;
using KissU.Util.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.IdentityServer.DbMigrator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceProviderFactory = new ServiceProviderFactory();
            var configuration = DbMigrationHelpers.BuildConfiguration();
            var services = new ServiceCollection();
            services.AddUnitOfWork<IIdentityServerUnitOfWork, DesignTimeDbContext>(
                configuration.GetConnectionString(DbConstants.ConnectionStringName));
            var containerBuilder = serviceProviderFactory.CreateBuilder(services);
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(containerBuilder);
            await DbMigrationHelpers.MigrateAsync<DesignTimeDbContext>(serviceProvider);
            Console.WriteLine("Press ENTER to stop application...");
            Console.ReadLine();
        }
    }
}