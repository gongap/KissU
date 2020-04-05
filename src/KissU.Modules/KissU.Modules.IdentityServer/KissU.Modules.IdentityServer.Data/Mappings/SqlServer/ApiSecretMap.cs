using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// API密钥映射配置
    /// </summary>
    public class ApiSecretMap : EntityMap<ApiSecret>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<ApiSecret> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "ApiSecrets", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<ApiSecret> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Value).HasMaxLength(4000).IsRequired();
            builder.Property(x => x.Type).HasMaxLength(250).IsRequired();
        }
    }
}