﻿using Microsoft.EntityFrameworkCore;

namespace GreatWall.Data.UnitOfWorks.PgSql {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public class GreatWallUnitOfWork : Util.Datas.Ef.PgSql.UnitOfWork,IGreatWallUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public GreatWallUnitOfWork( DbContextOptions<GreatWallUnitOfWork> options ) : base( options ) {
        }
    }
}