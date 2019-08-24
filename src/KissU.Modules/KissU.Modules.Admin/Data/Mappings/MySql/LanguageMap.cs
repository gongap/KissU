using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.MySql 
{
    /// <summary>
    /// 语言国际化映射配置
    /// </summary>
    public class LanguageMap : Util.Datas.Ef.MySql.AggregateRootMap<Language> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Language> builder ) 
		{
            builder.ToTable( "Systems.Language" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Language> builder ) 
		{
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.HasMany(b => b.Details).WithOne().HasForeignKey(x=>x.MainId);
        }
    }
}
