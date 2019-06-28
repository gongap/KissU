using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.SqlServer 
{
    /// <summary>
    /// 链接映射配置
    /// </summary>
    public class LinkMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Link> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Link> builder ) 
		{
            builder.ToTable( "Link", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Link> builder ) 
		{
            //
            builder.Property(t => t.Id)
                .HasColumnName("LinkId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}