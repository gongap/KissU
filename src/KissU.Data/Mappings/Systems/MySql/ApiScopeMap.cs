using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.MySql 
{
    /// <summary>
    /// Api许可范围映射配置
    /// </summary>
    public class ApiScopeMap : Util.Datas.Ef.MySql.AggregateRootMap<ApiScope> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ApiScope> builder ) 
		{
            builder.ToTable( "Systems.ApiScope" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ApiScope> builder ) 
		{
            //
            builder.Property(t => t.Id)
                .HasColumnName("ApiScopeId");
        }
    }
}