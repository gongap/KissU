// <copyright file="UserMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.GreatWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Util.Datas.Ef.SqlServer;

namespace KissU.Modules.GreatWall.Data.Mappings.SqlServer
{
    /// <summary>
    /// 用户映射配置
    /// </summary>
    public class UserMap : AggregateRootMap<User>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Id).HasColumnName("UserId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
