﻿using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Data;
using KissU.Util.Datas.SqlServer;
using KissU.Util.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.GreatWall.DbMigrator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceProviderFactory = new ServiceProviderFactory();
            var configuration = DbMigrationHelpers.BuildConfiguration();
            var services = new ServiceCollection();
            services.AddUnitOfWork<IGreatWallUnitOfWork, DesignTimeDbContext>(
                configuration.GetConnectionString("DefaultConnection"));
            var containerBuilder = serviceProviderFactory.CreateBuilder(services);
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(containerBuilder);
            await DbMigrationHelpers.MigrateAsync<DesignTimeDbContext>(serviceProvider);
            Console.WriteLine("Press ENTER to stop application...");
            Console.ReadLine();
        }
    }
}