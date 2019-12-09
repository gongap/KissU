// <copyright file="ApplicationPoMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    using KissU.Modules.GreatWall.Data.Pos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Util.Datas.Ef.PgSql;

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
            builder.ToTable("Application", "systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApplicationPo> builder)
        {
            builder.Property(t => t.Id).HasColumnName("ApplicationId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
