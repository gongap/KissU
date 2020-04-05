using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 应用程序声明映射配置
    /// </summary>
    public class ClientClaimMap : EntityMap<ClientClaim>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "ClientClaims", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.Property(x => x.Type).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(250).IsRequired();
        }
    }
}