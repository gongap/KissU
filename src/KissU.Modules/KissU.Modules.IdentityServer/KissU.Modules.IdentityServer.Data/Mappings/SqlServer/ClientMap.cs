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
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "Clients", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ProtocolType).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ClientName).HasMaxLength(200);
            builder.Property(x => x.ClientUri).HasMaxLength(2000);
            builder.Property(x => x.LogoUri).HasMaxLength(2000);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.FrontChannelLogoutUri).HasMaxLength(2000);
            builder.Property(x => x.BackChannelLogoutUri).HasMaxLength(2000);
            builder.Property(x => x.ClientClaimsPrefix).HasMaxLength(200);
            builder.Property(x => x.PairWiseSubjectSalt).HasMaxLength(200);
            builder.Property(x => x.UserCodeType).HasMaxLength(100);
            builder.HasIndex(x => x.ClientId).IsUnique();
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapAssociations(EntityTypeBuilder<Client> builder)
        {
            builder.OwnsMany(t => t.RedirectUris, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientRedirectUris", DbConstants.DbSchema);
                p.Property(x => x.RedirectUri).HasMaxLength(2000).IsRequired();
            });
            builder.OwnsMany(t => t.AllowedGrantTypes, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientGrantTypes", DbConstants.DbSchema);
                p.Property(x => x.GrantType).HasMaxLength(250).IsRequired();
            });
            builder.OwnsMany(t => t.PostLogoutRedirectUris, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientPostLogoutRedirectUris", DbConstants.DbSchema);
                p.Property(x => x.PostLogoutRedirectUri).HasMaxLength(2000).IsRequired();
            });
            builder.OwnsMany(t => t.AllowedScopes, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientScopes", DbConstants.DbSchema);
                p.Property(x => x.Scope).HasMaxLength(200).IsRequired();
            });
            builder.OwnsMany(t => t.IdentityProviderRestrictions, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientIdPRestrictions", DbConstants.DbSchema);
                p.Property(x => x.Provider).HasMaxLength(200).IsRequired();
            });
            builder.OwnsMany(t => t.AllowedCorsOrigins, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientCorsOrigins", DbConstants.DbSchema);
                p.Property(x => x.Origin).HasMaxLength(150).IsRequired();
            });
            builder.OwnsMany(t => t.Properties, p =>
            {
                p.WithOwner(x => x.Client);
                p.ToTable(DbConstants.DbTablePrefix + "ClientPropertys", DbConstants.DbSchema);
                p.Property(x => x.Key).HasMaxLength(250).IsRequired();
                p.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            });

            builder.HasMany(x => x.ClientSecrets).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Claims).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}