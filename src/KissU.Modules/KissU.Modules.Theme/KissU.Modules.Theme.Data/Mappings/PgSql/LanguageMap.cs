// <copyright file="LanguageMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.Theme.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Util.Datas.Ef.PgSql;

namespace KissU.Modules.Theme.Data.Mappings.PgSql
{
    /// <summary>
    /// 语言国际化映射配置
    /// </summary>
    public class LanguageMap : AggregateRootMap<Language>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language", "systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Language> builder)
        {
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.HasMany(b => b.Details).WithOne().HasForeignKey(x => x.MainId);
        }
    }
}
