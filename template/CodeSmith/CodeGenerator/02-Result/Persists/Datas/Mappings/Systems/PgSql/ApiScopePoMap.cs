using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GreatWall.Data.Pos.Systems;

namespace GreatWall.Data.Mappings.Systems.PgSql {
    /// <summary>
    /// Api许可范围持久化对象映射配置
    /// </summary>
    public class ApiScopePoMap : Util.Datas.Ef.PgSql.AggregateRootMap<ApiScopePo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ApiScopePo> builder ) {
            builder.ToTable( "ApiScope", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ApiScopePo> builder ) {
            //
            builder.Property(t => t.Id)
                .HasColumnName("ApiScopeId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}