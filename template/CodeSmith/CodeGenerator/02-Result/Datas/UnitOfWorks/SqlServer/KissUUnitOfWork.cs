using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace GreatWall.Data.UnitOfWorks.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class KissUUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork,IKissUUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public KissUUnitOfWork( DbContextOptions<KissUUnitOfWork> options ) : base( options ) {
        }
    }
}