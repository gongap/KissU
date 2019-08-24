using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.Data.Mappings.Systems.SqlServer 
{
    /// <summary>
    /// 语言国际化映射配置
    /// </summary>
    public class LanguageMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Language> 
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
