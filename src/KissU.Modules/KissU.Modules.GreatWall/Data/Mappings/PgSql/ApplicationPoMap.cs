﻿using GreatWall.Data.Pos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreatWall.Data.Mappings.PgSql {
    /// <summary>
    /// 应用程序持久化对象映射配置
    /// </summary>
    public class ApplicationPoMap : Util.Datas.Ef.PgSql.AggregateRootMap<ApplicationPo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ApplicationPo> builder ) {
            builder.ToTable( "Application", "Systems" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ApplicationPo> builder ) {
            builder.Property( t => t.Id ).HasColumnName( "ApplicationId" );
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
