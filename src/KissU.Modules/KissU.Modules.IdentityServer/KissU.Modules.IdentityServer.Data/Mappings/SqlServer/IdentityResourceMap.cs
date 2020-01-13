using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 身份资源映射配置
    /// </summary>
    public class IdentityResourceMap : AggregateRootMap<IdentityResource>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.ToTable(IdentityServerDataConstants.DbTablePrefix + "IdentityResources", IdentityServerDataConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<IdentityResource> builder)
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
        protected override void MapAssociations(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.OwnsMany(t => t.UserClaims, p =>
            {
                p.ToTable(IdentityServerDataConstants.DbTablePrefix + "IdentityClaims", IdentityServerDataConstants.DbSchema);
                p.WithOwner(x => x.Owner);
                p.Property(x => x.Type).HasMaxLength(200).IsRequired();
            });

            builder.OwnsMany(t => t.Properties, p =>
            {
                p.ToTable(IdentityServerDataConstants.DbTablePrefix + "IdentityProperties", IdentityServerDataConstants.DbSchema);
                p.Property(x => x.Key).HasMaxLength(250).IsRequired();
                p.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            });
        }
    }
}