using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Data.Mappings.Systems.SqlServer {
    /// <summary>
    /// 资源映射配置
    /// </summary>
    public class ResourceMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Resource> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Resource> builder ) {
            builder.ToTable( "Resource", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Resource> builder ) {
            //资源标识
            builder.Property(t => t.Id)
                .HasColumnName("ResourceId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
            builder.Property( t => t.Path ).HasColumnName( "Path" );
            builder.Property( t => t.Level ).HasColumnName( "Level" );
        }
    }
}