using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class DeviceFlowCodeMap : AggregateRootMap<DeviceFlowCode>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<DeviceFlowCode> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "DeviceFlowCodes", DbConstants.DbSchema);
        }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<DeviceFlowCode> builder)
        {
            builder.HasKey(x => new {x.UserCode});
            builder.Property(x => x.DeviceCode).HasMaxLength(200).IsRequired();
            builder.Property(x => x.UserCode).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SubjectId).HasMaxLength(200);
            builder.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.Expiration).IsRequired();
            // 50000 chosen to be explicit to allow enough size to avoid truncation, yet stay beneath the MySql row size limit of ~65K
            // apparently anything over 4K converts to nvarchar(max) on SqlServer
            builder.Property(x => x.Data).HasMaxLength(50000).IsRequired();
            builder.HasIndex(x => x.DeviceCode).IsUnique();
            builder.HasIndex(x => x.Expiration);
        }
    }
}