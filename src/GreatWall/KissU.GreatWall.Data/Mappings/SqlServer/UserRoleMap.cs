using GreatWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Ef.SqlServer;

namespace GreatWall.Data.Mappings.SqlServer {
    /// <summary>
    /// 用户角色映射配置
    /// </summary>
    public class UserRoleMap : EntityMap<UserRole> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<UserRole> builder ) {
            builder.ToTable( "UserRole", "Systems" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<UserRole> builder ) {
            builder.HasKey( t => new { t.UserId, t.RoleId } );
        }
    }
}