using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.GreatWall.Data.Pos.Systems;

namespace KissU.GreatWall.Data.Mappings.Systems.SqlServer {
    /// <summary>
    /// Api资源持久化对象映射配置
    /// </summary>
    public class ApiPoMap : Util.Datas.Ef.SqlServer.AggregateRootMap<ApiPo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ApiPo> builder ) {
            builder.ToTable( "Api", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ApiPo> builder ) {
            //
            builder.Property(t => t.Id)
                .HasColumnName("ApiId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}