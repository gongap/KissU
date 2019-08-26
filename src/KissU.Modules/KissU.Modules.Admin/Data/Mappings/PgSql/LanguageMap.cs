using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Modules.Admin.Domain.Models;

namespace KissU.Modules.Admin.Data.Mappings.PgSql 
{
    /// <summary>
    /// 语言国际化映射配置
    /// </summary>
    public class LanguageMap : Util.Datas.Ef.PgSql.AggregateRootMap<Language> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Language> builder ) 
		{
            builder.ToTable( "Language", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Language> builder ) 
		{
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.HasMany(b => b.Details).WithOne().HasForeignKey(x => x.MainId);
        }
    }
}
