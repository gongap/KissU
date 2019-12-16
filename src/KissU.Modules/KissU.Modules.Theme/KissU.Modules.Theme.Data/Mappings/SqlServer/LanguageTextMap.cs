// <copyright file="LanguageTextMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.Theme.Domain.Models;
using KissU.Util.Datas.Ef.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.Theme.Data.Mappings.SqlServer
{
    /// <summary>
    /// 语言国际化配置映射配置
    /// </summary>
    public class LanguageTextMap : EntityMap<LanguageDetail>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<LanguageDetail> builder)
        {
            builder.ToTable("LanguageDetail", "systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<LanguageDetail> builder)
        {
            builder.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
