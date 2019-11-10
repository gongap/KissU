using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.SqlServer;
using Util.Reflections;

namespace KissU.Modules.Theme.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class ThemeUnitOfWork : UnitOfWork, IThemeUnitOfWork
    {
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;

        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="finder">类型查找器</param>
        public ThemeUnitOfWork(DbContextOptions options, IFind finder = null) : base(options)
        {
            _finder = finder ?? new Finder();
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return _finder.GetAssemblies().ToArray();
        }
    }
}
