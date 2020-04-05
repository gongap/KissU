using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 操作数据映射配置
    /// </summary>
    public class PersistedGrantMap : AggregateRootMap<PersistedGrant>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "PersistedGrants", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.Property(x => x.Key).HasMaxLength(200).ValueGeneratedNever();
            builder.Property(x => x.Type).HasMaxLength(50).IsRequired();
            builder.Property(x => x.SubjectId).HasMaxLength(200);
            builder.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreationTime).IsRequired();
            // 50000 chosen to be explicit to allow enough size to avoid truncation, yet stay beneath the MySql row size limit of ~65K
            // apparently anything over 4K converts to nvarchar(max) on SqlServer
            builder.Property(x => x.Data).HasMaxLength(50000).IsRequired();
            builder.HasIndex(x => new {x.SubjectId, x.ClientId, x.Type});
            builder.HasIndex(x => x.Expiration);
        }
    }
}