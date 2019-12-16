// <copyright file="ClaimMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.PgSql.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 声明映射配置
    /// </summary>
    public class ClaimMap : AggregateRootMap<Claim>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claim", "systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Claim> builder)
        {
            builder.Property(t => t.Id).HasColumnName("ClaimId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
