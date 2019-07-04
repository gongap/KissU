using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.GreatWall.Data.Pos.Systems;

namespace KissU.GreatWall.Data.Mappings.Systems.SqlServer {
    /// <summary>
    /// 用户持久化对象映射配置
    /// </summary>
    public class UserPoMap : Util.Datas.Ef.SqlServer.AggregateRootMap<UserPo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<UserPo> builder ) {
            builder.ToTable( "User", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<UserPo> builder ) {
            //用户标识
            builder.Property(t => t.Id)
                .HasColumnName("UserId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}