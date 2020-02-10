using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.PgSql.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 用户映射配置
    /// </summary>
    public class UserMap : AggregateRootMap<User>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "Users", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}