using System.Reflection;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.IdentityServer.DbMigrator
{
    /// <summary>
    /// 此DbContext仅用于数据库迁移。
    /// </summary>
    public class DesignTimeDbContext : IdentityServerUnitOfWork
    {
        /// <summary>
        ///  初始化DbContext的新实例。
        /// </summary>
        public DesignTimeDbContext(DbContextOptions<IdentityServerUnitOfWork> options) : base(options) { }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return Finder.GetAssemblies().ToArray();
        }
    }
}
