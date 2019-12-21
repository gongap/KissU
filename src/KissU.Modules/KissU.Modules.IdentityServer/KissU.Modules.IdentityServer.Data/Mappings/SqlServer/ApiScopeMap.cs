// <copyright file="ApiResourceScopeMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// Api许可范围映射配置
    /// </summary>
    public class ApiScopeMap : EntityMap<ApiScope>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ApiScope> builder)
        {
            builder.ToTable(Consts.DbTablePrefix + "ApiScopes", Consts.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApiScope> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DisplayName).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.HasIndex(x => x.Name).IsUnique();
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations(EntityTypeBuilder<ApiScope> builder)
        {
            builder.OwnsMany(t => t.UserClaims, p =>
            {
                p.ToTable(Consts.DbTablePrefix + "ApiScopeClaims", Consts.DbSchema);
                p.Property(x => x.Type).HasMaxLength(200).IsRequired();
            });
        }
    }
}
