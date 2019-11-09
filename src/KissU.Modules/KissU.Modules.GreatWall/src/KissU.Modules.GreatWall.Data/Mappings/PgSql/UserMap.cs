using KissU.Modules.GreatWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 用户映射配置
    /// </summary>
    public class UserMap : Util.Datas.Ef.PgSql.AggregateRootMap<User>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Systems");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Id).HasColumnName("UserId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}