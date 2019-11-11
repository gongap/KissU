using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util;
using Util.Datas.Ef;

namespace KissU.Modules.GreatWall.DbMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = DbMigrationHelpers.BuildConfiguration();
            var services = new ServiceCollection();
            services.AddUnitOfWork<IGreatWallUnitOfWork, DesignTimeDbContext>(configuration.GetConnectionString("DefaultConnection"));
            var serviceProvider = services.AddUtil();
            await DbMigrationHelpers.MigrateAsync<DesignTimeDbContext>(serviceProvider);
            Console.ReadLine();
        }
    }
}
