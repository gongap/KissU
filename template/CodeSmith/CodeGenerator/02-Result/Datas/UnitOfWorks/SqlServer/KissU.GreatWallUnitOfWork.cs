using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace GreatWall.Data.UnitOfWorks.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class KissU.GreatWallUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork,IKissU.GreatWallUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public KissU.GreatWallUnitOfWork( DbContextOptions<KissU.GreatWallUnitOfWork> options ) : base( options ) {
        }
    }
}