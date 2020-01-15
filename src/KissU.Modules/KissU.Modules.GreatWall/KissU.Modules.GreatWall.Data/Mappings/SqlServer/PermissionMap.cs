using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.SqlServer
{
    /// <summary>
    /// 权限映射配置
    /// </summary>
    public class PermissionMap : AggregateRootMap<Permission>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(GreatWallDataConstants.DbTablePrefix + "Permissions", GreatWallDataConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Permission> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}