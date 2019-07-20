using GreatWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreatWall.Data.Mappings.SqlServer {
    /// <summary>
    /// 声明映射配置
    /// </summary>
    public class ClaimMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Claim> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Claim> builder ) {
            builder.ToTable( "Claim", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Claim> builder ) {
            //声明标识
            builder.Property(t => t.Id)
                .HasColumnName("ClaimId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
