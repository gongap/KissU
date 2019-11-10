using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Util.Helpers;

namespace KissU.Modules.Theme.Data.DbMigrations
{
    /// <summary>
    /// EF Core控制台命令需要该类
    /// 如Add-Migration和Update-Database命令
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DesignTimeDbContext>
    {
        /// <summary>创建派生上下文的新实例。</summary>
        /// <param name="args"> 设计时服务提供的参数。 </param>
        /// <returns> DbContext的实例。</returns>
        public DesignTimeDbContext CreateDbContext(string[] args)
        {
            Ioc.Register();
            var builder = new DbContextOptionsBuilder().UseSqlServer(@"Server=.;Database=KissU;uid=sa;pwd=saP@ss123;MultipleActiveResultSets=true");
            return new DesignTimeDbContext(builder.Options);
        }
    }
}
