using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Data.Pos.Systems;

namespace KissU.Data.Mappings.Systems.SqlServer 
{
    /// <summary>
    /// 菜单持久化对象映射配置
    /// </summary>
    public class MenuPoMap : Util.Datas.Ef.SqlServer.AggregateRootMap<MenuPo> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<MenuPo> builder ) 
		{
            builder.ToTable( "Menu", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<MenuPo> builder ) 
		{
            //
            builder.Property(t => t.Id)
                .HasColumnName("MenuId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}