using KissU.Util.Datas.Tests.Integration.Commons.Datas.PgSql.Configs;
using Microsoft.EntityFrameworkCore;

namespace KissU.Util.Datas.Tests.Integration.Ef.PgSql.UnitOfWorks {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public class PgSqlUnitOfWork : Util.Datas.Ef.PgSql.UnitOfWork, IPgSqlUnitOfWork {
        /// <summary>
        /// 初始化PgSql工作单元
        /// </summary>
        public PgSqlUnitOfWork() : base( new DbContextOptionsBuilder().UseNpgsql( AppConfig.Connection ).Options ) {
        }
    }
}