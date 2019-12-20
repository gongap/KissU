// <copyright file="ApiResourceMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// API资源映射配置
    /// </summary>
    public class ApiResourceMap : AggregateRootMap<ApiResource>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ApiResource> builder)
        {
            builder.ToTable(Consts.DbTablePrefix + "ApiResources", Consts.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApiResource> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DisplayName).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.OwnsMany(t => t.UserClaims, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "IdentityClaims", Consts.DbSchema);
                ob.Property(x => x.Type);
            });

            builder.OwnsMany(t => t.Properties, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "IdentityProperties", Consts.DbSchema);
                ob.Property(x => x.Key);
                ob.Property(x => x.Value);
            });

            builder.HasMany(x => x.Secrets).WithOne(x => x.ApiResource).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Scopes).WithOne(x => x.ApiResource).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
