using KissU.Modules.GreatWall.Data.Pos;
using KissU.Util.Datas.PgSql.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 资源映射配置
    /// </summary>
    public class ResourcePoMap : AggregateRootMap<ResourcePo>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<ResourcePo> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "Resources", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<ResourcePo> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}