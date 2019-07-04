using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KFNets.Veterinary.Data.Pos.Systems;

namespace KFNets.Veterinary.Data.Mappings.Systems.SqlServer {
    /// <summary>
    /// 角色持久化对象映射配置
    /// </summary>
    public class RolePoMap : Util.Datas.Ef.SqlServer.AggregateRootMap<RolePo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<RolePo> builder ) {
            builder.ToTable( "Role", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<RolePo> builder ) {
            //角色编号
            builder.Property(t => t.Id)
                .HasColumnName("RoleId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}