// <copyright file="ClientMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 应用程序映射配置
    /// </summary>
    public class ClientMap : AggregateRootMap<Client>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(Consts.DbTablePrefix + "Clients", Consts.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Client> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
            builder.OwnsMany(t => t.RedirectUris, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientRedirectUris", Consts.DbSchema);
                ob.Property(x => x.RedirectUri);
            });
            builder.OwnsMany(t => t.AllowedGrantTypes, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientGrantTypes", Consts.DbSchema);
                ob.Property(x => x.GrantType);
            });
            builder.OwnsMany(t => t.PostLogoutRedirectUris, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientPostLogoutRedirectUris", Consts.DbSchema);
                ob.Property(x => x.PostLogoutRedirectUri);
            });
            builder.OwnsMany(t => t.AllowedScopes, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientScopes", Consts.DbSchema);
                ob.Property(x => x.Scope);
            });
            builder.OwnsMany(t => t.IdentityProviderRestrictions, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientIdPRestrictions", Consts.DbSchema);
                ob.Property(x => x.Provider);
            });
            builder.OwnsMany(t => t.AllowedCorsOrigins, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientCorsOrigins", Consts.DbSchema);
                ob.Property(x => x.Origin);
            });
            builder.OwnsMany(t => t.Properties, ob =>
            {
                ob.ToTable(Consts.DbTablePrefix + "ClientPropertys", Consts.DbSchema);
                ob.Property(x => x.Key);
                ob.Property(x => x.Value);
            });
        }
    }
}
