using KissU.GreatWall.Data.Pos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.GreatWall.Data.Mappings.SqlServer {
    /// <summary>
    /// 资源映射配置
    /// </summary>
    public class ResourceMap : Util.Datas.Ef.SqlServer.AggregateRootMap<ResourcePo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ResourcePo> builder ) {
            builder.ToTable( "Resource", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ResourcePo> builder ) {
            builder.Property(t => t.Id).HasColumnName("ResourceId");
            builder.Property( t => t.Path ).HasColumnName( "Path" );
            builder.Property( t => t.Level ).HasColumnName( "Level" );
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
