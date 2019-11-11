﻿using System;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.Theme.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util;
using Util.Datas.Ef;

namespace KissU.Modules.Theme.DbMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = DbMigrationHelpers.BuildConfiguration();
            var services = new ServiceCollection();
            services.AddUnitOfWork<IThemeUnitOfWork, DesignTimeDbContext>(configuration.GetConnectionString("DefaultConnection"));
            var serviceProvider = services.AddUtil();
            await DbMigrationHelpers.MigrateAsync<DesignTimeDbContext>(serviceProvider);
            Console.ReadLine();
        }
    }
}
