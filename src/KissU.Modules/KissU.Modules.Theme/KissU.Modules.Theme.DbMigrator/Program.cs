// <copyright file="Program.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.DbMigrator
{
    using System;
    using System.Threading.Tasks;
    using KissU.Modules.Theme.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Util;
    using Util.Datas.Ef;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var configuration = DbMigrationHelpers.BuildConfiguration();
            var services = new ServiceCollection();
            services.AddUnitOfWork<IThemeUnitOfWork, DesignTimeDbContext>(
                configuration.GetConnectionString("DefaultConnection"));
            var serviceProvider = services.AddUtil();
            await DbMigrationHelpers.MigrateAsync<DesignTimeDbContext>(serviceProvider);
            Console.WriteLine("Press ENTER to stop application...");
            Console.ReadLine();
        }
    }
}
