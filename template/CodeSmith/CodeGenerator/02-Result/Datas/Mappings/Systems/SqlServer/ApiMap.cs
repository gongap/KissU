using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Data.Mappings.Systems.SqlServer {
    /// <summary>
    /// Api资源映射配置
    /// </summary>
    public class ApiMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Api> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Api> builder ) {
            builder.ToTable( "Api", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Api> builder ) {
            //
            builder.Property(t => t.Id)
                .HasColumnName("ApiId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}