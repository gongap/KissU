// <copyright file="LanguageDetailMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Data.Mappings.PgSql
{
    using KissU.Modules.Theme.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Util.Datas.Ef.PgSql;

    /// <summary>
    ///     语言国际化配置映射配置
    /// </summary>
    public class LanguageDetailMap : EntityMap<LanguageDetail>
    {
        /// <summary>
        ///     映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<LanguageDetail> builder)
        {
            builder.ToTable("LanguageDetail", "systems");
        }

        /// <summary>
        ///     映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<LanguageDetail> builder)
        {
            //标识
            builder.Property(t => t.Id)
                .HasColumnName("Id");
        }
    }
}
