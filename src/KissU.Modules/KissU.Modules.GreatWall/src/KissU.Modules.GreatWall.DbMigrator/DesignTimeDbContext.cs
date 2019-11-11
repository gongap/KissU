using System.Reflection;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.GreatWall.DbMigrator
{
    /// <summary>
    /// 此DbContext仅用于数据库迁移。
    /// </summary>
    public class DesignTimeDbContext : GreatWallUnitOfWork
    {
        /// <summary>
        ///  初始化DbContext的新实例。
        /// </summary>
        public DesignTimeDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return Finder.GetAssemblies().ToArray();
        }
    }
}
