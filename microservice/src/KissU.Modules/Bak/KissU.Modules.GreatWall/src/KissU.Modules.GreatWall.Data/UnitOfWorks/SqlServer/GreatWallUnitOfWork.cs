using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class GreatWallUnitOfWork : UnitOfWork, IGreatWallUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public GreatWallUnitOfWork(DbContextOptions<GreatWallUnitOfWork> options) : base(options)
        {
        }
    }
}