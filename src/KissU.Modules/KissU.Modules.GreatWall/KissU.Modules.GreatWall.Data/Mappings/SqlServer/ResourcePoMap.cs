﻿using KissU.Modules.GreatWall.Data.Pos;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.SqlServer
{
    /// <summary>
    /// 资源映射配置
    /// </summary>
    public class ResourcePoMap : AggregateRootMap<ResourcePo>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ResourcePo> builder)
        {
            builder.ToTable("Resource", "Systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ResourcePo> builder)
        {
            builder.Property(t => t.Id).HasColumnName("ResourceId");
            builder.Property(t => t.Path).HasColumnName("Path");
            builder.Property(t => t.Level).HasColumnName("Level");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}