using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Data.Pos.Systems;

namespace KissU.Data.Mappings.Systems.PgSql {
    /// <summary>
    /// 持久化对象映射配置
    /// </summary>
    public class MenuPoMap : Util.Datas.Ef.PgSql.AggregateRootMap<MenuPo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<MenuPo> builder ) {
            builder.ToTable( "Menu", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<MenuPo> builder ) {
            //
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}