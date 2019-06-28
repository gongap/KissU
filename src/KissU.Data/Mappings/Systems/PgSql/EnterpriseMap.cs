using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.PgSql 
{
    /// <summary>
    /// 企业映射配置
    /// </summary>
    public class EnterpriseMap : Util.Datas.Ef.PgSql.AggregateRootMap<Enterprise> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Enterprise> builder ) 
		{
            builder.ToTable( "Enterprise", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Enterprise> builder ) 
		{
            //
            builder.Property(t => t.Id)
                .HasColumnName("EnterpriseId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}