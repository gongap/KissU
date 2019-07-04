using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.Data.Mappings.Systems.MySql 
{
    /// <summary>
    /// Api资源映射配置
    /// </summary>
    public class ApiMap : Util.Datas.Ef.MySql.AggregateRootMap<Api> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Api> builder ) 
		{
            builder.ToTable( "Systems.Api" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Api> builder ) 
		{
            //
            builder.Property(t => t.Id)
                .HasColumnName("ApiId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}