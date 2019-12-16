// <copyright file="PermissionMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.PgSql.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 权限映射配置
    /// </summary>
    public class PermissionMap : AggregateRootMap<Permission>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(t => t.Id).HasColumnName("PermissionId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
