using Microsoft.EntityFrameworkCore;
using Util.Reflections;

namespace KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class GreatWallUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, Data.IGreatWallUnitOfWork
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
        public GreatWallUnitOfWork(DbContextOptions options, IFind finder = null) : base(options)
        {
            Finder = finder ?? new Finder();
        }
    }
}
