using System.Reflection;
using KissU.Modules.Theme.Data;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.SqlServer;
using Util.Reflections;

namespace KissU.Modules.Theme.DbMigrator
{
    /// <summary>
    /// 此DbContext仅用于数据库迁移。
    /// </summary>
    public class DesignTimeDbContext : UnitOfWork, IThemeUnitOfWork
    {
        /// <summary>
        /// 类型查找器
        /// </summary>
        protected readonly IFind Finder;

        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="finder">类型查找器</param>
        public DesignTimeDbContext(DbContextOptions<DesignTimeDbContext> options, IFind finder = null) : base(options)
        {
            Finder = finder ?? new Finder();
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return Finder.GetAssemblies().ToArray();
        }
    }
}
