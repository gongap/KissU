using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.SqlServer 
{
    /// <summary>
    /// 语言国际化配置映射配置
    /// </summary>
    public class LanguageTextMap : Util.Datas.Ef.SqlServer.EntityMap<LanguageDetail> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<LanguageDetail> builder ) 
		{
            builder.ToTable("LanguageDetail", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<LanguageDetail> builder ) 
		{
            builder.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
