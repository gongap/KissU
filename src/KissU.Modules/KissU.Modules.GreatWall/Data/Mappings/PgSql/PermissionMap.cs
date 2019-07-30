using GreatWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreatWall.Data.Mappings.PgSql {
    /// <summary>
    /// 权限映射配置
    /// </summary>
    public class PermissionMap : Util.Datas.Ef.PgSql.AggregateRootMap<Permission> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Permission> builder ) {
            builder.ToTable( "Permission", "Systems" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Permission> builder ) {
            builder.Property( t => t.Id ).HasColumnName( "PermissionId" );
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
