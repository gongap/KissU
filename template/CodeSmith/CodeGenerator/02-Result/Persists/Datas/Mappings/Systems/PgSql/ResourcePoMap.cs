using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GreatWall.Data.Pos.Systems;

namespace GreatWall.Data.Mappings.Systems.PgSql {
    /// <summary>
    /// 资源持久化对象映射配置
    /// </summary>
    public class ResourcePoMap : Util.Datas.Ef.PgSql.AggregateRootMap<ResourcePo> {
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
            //资源标识
            builder.Property(t => t.Id)
                .HasColumnName("ResourceId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}