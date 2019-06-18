using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.PgSql {
    /// <summary>
    /// 菜单映射配置
    /// </summary>
    public class MenuMap : Util.Datas.Ef.PgSql.AggregateRootMap<Menu> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Menu> builder ) {
            builder.ToTable( "Menu", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Menu> builder ) {
            //
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
            builder.Property( t => t.Path ).HasColumnName( "Path" );
            builder.Property( t => t.Level ).HasColumnName( "Level" );
        }
    }
}