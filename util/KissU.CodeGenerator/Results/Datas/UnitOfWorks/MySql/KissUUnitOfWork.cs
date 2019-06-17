using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace KissU.Data.UnitOfWorks.MySql {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class KissUUnitOfWork : Util.Datas.Ef.MySql.UnitOfWork,IKissUUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="unitOfWorkManager">工作单元服务</param>
        public KissUUnitOfWork( DbContextOptions options, IUnitOfWorkManager unitOfWorkManager ) : base( options, unitOfWorkManager ) {
        }
    }
}