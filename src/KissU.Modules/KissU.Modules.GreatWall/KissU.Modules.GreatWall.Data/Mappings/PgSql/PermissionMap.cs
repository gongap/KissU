using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.PgSql.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.PgSql
{
    /// <summary>
    /// 权限映射配置
    /// </summary>
    public class PermissionMap : AggregateRootMap<Permission>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "Permissions", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<Permission> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}