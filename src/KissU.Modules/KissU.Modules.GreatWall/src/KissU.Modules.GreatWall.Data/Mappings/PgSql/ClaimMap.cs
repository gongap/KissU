// <copyright file="ClaimMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    using KissU.Modules.GreatWall.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Util.Datas.Ef.PgSql;

    /// <summary>
    ///     声明映射配置
    /// </summary>
    public class ClaimMap : AggregateRootMap<Claim>
    {
        /// <summary>
        ///     映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claim", "systems");
        }

        /// <summary>
        ///     映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Claim> builder)
        {
            builder.Property(t => t.Id).HasColumnName("ClaimId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
