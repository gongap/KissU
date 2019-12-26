using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.GreatWall.Data.UnitOfWorks.PgSql {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public class GreatWallUnitOfWork : Util.Datas.PgSql.Ef.UnitOfWork,Data.IGreatWallUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public GreatWallUnitOfWork( DbContextOptions<GreatWallUnitOfWork> options ) : base( options ) {
        }
    }
}