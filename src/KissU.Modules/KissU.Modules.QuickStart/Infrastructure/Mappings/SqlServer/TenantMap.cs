using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Modules.QuickStart.Domain.Models;

namespace KissU.Modules.QuickStart.Infrastructure.Mappings.SqlServer {
    /// <summary>
    /// 租户映射配置
    /// </summary>
    public class TenantMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Tenant> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Tenant> builder ) {
            builder.ToTable("Tenant", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Tenant> builder ) {
            //租户编号
            builder.Property(t => t.Id)
                .HasColumnName("TenantId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}