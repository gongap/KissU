using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.SqlServer
{
    /// <summary>
    /// 用户角色映射配置
    /// </summary>
    public class UserRoleMap : EntityMap<UserRole>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(GreatWallDataConstants.DbTablePrefix + "UserRoles", GreatWallDataConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(t => new {t.UserId, t.RoleId});
        }
    }
}