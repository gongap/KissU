﻿using KissU.Modules.GreatWall.Data.Pos;
using KissU.Util.Datas.PgSql.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 应用程序持久化对象映射配置
    /// </summary>
    public class ApplicationPoMap : AggregateRootMap<ApplicationPo>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ApplicationPo> builder)
        {
            builder.ToTable(GreatWallDataConstants.DbTablePrefix + "Applications", GreatWallDataConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApplicationPo> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}