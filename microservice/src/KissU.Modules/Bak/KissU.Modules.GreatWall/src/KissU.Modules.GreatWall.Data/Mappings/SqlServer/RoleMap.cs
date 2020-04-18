using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.SqlServer
{
    /// <summary>
    /// 角色映射配置
    /// </summary>
    public class RoleMap : AggregateRootMap<Role>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "Roles", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<Role> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}